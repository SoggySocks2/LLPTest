using LLPTest.Data.Blogs.Seeds;
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
                    await SeedBlogAggregateAsync();
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

            _dbContext.Genders.AddRange(GenderSeed.Get(1, 4));
            _dbContext.Countries.AddRange(CountrySeed.Get(1, 4));
            await _dbContext.SaveChangesAsync();

            var genderIds = _dbContext.Genders.Local.Select(x=>x.Id).ToList();
            var countryIds = _dbContext.Countries.Local.Select(x=>x.Id).ToList();
            _dbContext.Customers.AddRange(CustomerSeed.GetTree(100, 3, genderIds, countryIds));
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedRetailerAggregateAsync()
        {
            if (await _dbContext.Retailers.AnyAsync()) return;

            _dbContext.Brands.AddRange(BrandSeed.Get(1, 4));
            await _dbContext.SaveChangesAsync();

            // Market -> Region -> Area
            _dbContext.Markets.AddRange(MarketSeed.GetTree(2, 2));
            await _dbContext.SaveChangesAsync();

            var areaIds = _dbContext.Areas.Local.Select(x => x.Id).ToList();
            var brandIds = _dbContext.Brands.Local.Select(x => x.Id).ToList();
            _dbContext.RetailerGroups.AddRange(RetailerGroupSeed.GetTree(8, 2, areaIds, brandIds));
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

        private async Task SeedBlogAggregateAsync()
        {
            if (await _dbContext.Authors.AnyAsync()) return;

            var authors = AuthorSeed.Get(1, 3);
            authors.Reverse(); // To preserve Id ordering while saving.
            _dbContext.Authors.AddRange(authors);
            await _dbContext.SaveChangesAsync();

            var authorIds = _dbContext.Authors.Local.Select(x => x.Id).ToList();
            var blogs = BlogSeed.Get(authorIds, 1, 9);
            blogs.Reverse(); // To preserve Id ordering while saving.
            _dbContext.Blogs.AddRange(blogs);
            await _dbContext.SaveChangesAsync();

            // Save in chunks to preserve the order in the generated keys.
            var blogIds = _dbContext.Blogs.Local.Select(x => x.Id).ToList();
            _dbContext.Posts.AddRange(PostSeed.Get(blogIds, 1, 9));
            await _dbContext.SaveChangesAsync();
            _dbContext.Posts.AddRange(PostSeed.Get(blogIds, 10, 18));
            await _dbContext.SaveChangesAsync();
            _dbContext.Posts.AddRange(PostSeed.Get(blogIds, 19, 27));
            await _dbContext.SaveChangesAsync();
        }
    }
}
