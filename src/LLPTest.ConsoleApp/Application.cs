using LLPTest.Data;
using Microsoft.EntityFrameworkCore;

namespace LLPTest.ConsoleApp
{
    public class Application
    {
        private readonly AppDbContext _dbContext;

        public Application(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RunAsync()
        {
            var customer = await _dbContext.Customers
                .Include(x => x.Addresses)
                .Include(x => x.Country)
                .Include(x => x.CustomerRetailerSites)
                .FirstOrDefaultAsync();

            var country = await _dbContext.Countries
                .Include(x => x.Customers)
                .FirstOrDefaultAsync();

            var blog = await _dbContext.Blogs
                .Include(x => x.Posts)
                .Include(x => x.Author)
                .Include(x => x.BlogImage)
                .FirstOrDefaultAsync();

            var areas = await _dbContext.Areas
                .Include(x => x.Region.Market)
                .ToListAsync();

            var markets = await _dbContext.Markets
                        .Include(x => x.Regions)
                        .ThenInclude(x => x.Areas)
                        .ThenInclude(x => x.Retailers)
                        .ThenInclude(x => x.RetailerSites)
                        .ToListAsync();

            var retailers = await _dbContext.Retailers
                .Include(x => x.Area.Region.Market)
                .Include(x => x.RetailerGroup)
                .Include(x => x.RetailerSites)
                    .ThenInclude(x => x.RetailerCodes)
                .Include(x => x.RetailerSites)
                    .ThenInclude(x => x.Brand)
                .ToListAsync();

            Print(customer);
            Print(country);
            Print(blog);
        }

        private static void Print<T>(T input)
        {
            Console.WriteLine();
            Console.WriteLine("##########################################################");
            Console.WriteLine($"{typeof(T).Name}:");
            Console.WriteLine(input?.ToString() ?? "Null value!");
            Console.WriteLine("##########################################################");
            Console.WriteLine();
        }
    }
}
