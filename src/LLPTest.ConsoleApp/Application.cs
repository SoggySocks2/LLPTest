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
            await Task.CompletedTask;

            var blogs = await _dbContext.Blogs
                .Include(x => x.Author)
                .Include(x => x.BlogImage)
                .Include(x => x.Posts)
                .ToListAsync();

            Print(blogs.FirstOrDefault());
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
