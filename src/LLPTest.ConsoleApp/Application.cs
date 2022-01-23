using LLPTest.Data;

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
        }
    }
}
