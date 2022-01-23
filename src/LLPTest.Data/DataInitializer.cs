using LLPTest.Data.Customers;
using LLPTest.Data.Customers.Seeds;
using LLPTest.Data.Retailers.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LLPTest.Data
{
    public class DataInitializer
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(AppDbContext dbContext, ILogger<DataInitializer> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task SeedAsync(bool isDevelopmentEnvironment, int retry = 0)
        {
            try
            {
                if (isDevelopmentEnvironment)
                {
                    _dbContext.Database.Migrate();

                    await SeedCustomerAggregateAsync();
                    await SeedRetailerAggregateAsync();
                    await SeedRelationshipsAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occurred while seeding customers: " + ex.Message);

                if (retry > 0)
                {
                    await SeedAsync(isDevelopmentEnvironment, retry - 1);
                }
            }
        }

        private async Task SeedCustomerAggregateAsync()
        {
            if (await _dbContext.Customers.AnyAsync()) return;

            var genders = GenderSeed.Get(1, 4);
            var countries = CountrySeed.Get(1, 4);

            _dbContext.Genders.AddRange(genders);
            _dbContext.Countries.AddRange(countries);
            await _dbContext.SaveChangesAsync();

            _dbContext.Customers.AddRange(CustomerSeed.Get(genders, countries, 100, 3));
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedRetailerAggregateAsync()
        {
            if (await _dbContext.Retailers.AnyAsync()) return;

            var retailerGroups = RetailerGroupSeed.Get(1, 4);
            var brands = BrandSeed.Get(1, 4);

            _dbContext.RetailerGroups.AddRange(retailerGroups);
            _dbContext.Brands.AddRange(brands);
            await _dbContext.SaveChangesAsync();

            _dbContext.Markets.AddRange(MarketSeed.GetTree(retailerGroups, brands, 2, 2));
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedRelationshipsAsync()
        {
            if (await _dbContext.CustomerRetailerSites.AnyAsync()) return;

            var customerIds = _dbContext.Customers.Local.Select(x => x.Id).ToList();
            var retailerSiteIds = _dbContext.RetailerSites.Local.Select(x => x.Id).ToList();
            var relationships = new List<CustomerRetailerSite>();

            for (int i = 0; i < customerIds.Count; i++)
            {
                relationships.Add(new CustomerRetailerSite(customerIds[i], retailerSiteIds[i % retailerSiteIds.Count]));
            }

            _dbContext.CustomerRetailerSites.AddRange(relationships);
            await _dbContext.SaveChangesAsync();
        }
    }
}
