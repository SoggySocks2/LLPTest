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
                .FirstOrDefaultAsync();

            var country = await _dbContext.Countries
                .Include(x => x.Customers)
                .FirstOrDefaultAsync();

            var blog = await _dbContext.Blogs
                .Include(x => x.Posts)
                .Include(x => x.Author)
                .FirstOrDefaultAsync();

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
