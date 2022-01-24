using LLPTest.Data.Blogs;
using LLPTest.Data.Customers;
using LLPTest.Data.Customers.Configuration;
using LLPTest.Data.Retailers;
using Microsoft.EntityFrameworkCore;

namespace LLPTest.Data
{
    public class AppDbContext : DbContext
    {
        private readonly static string _connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=LLPTest;Integrated Security=SSPI;ConnectRetryCount=0;";

        public DbSet<Gender> Genders { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;

        public DbSet<Market> Markets { get; set; } = default!;
        public DbSet<Region> Regions { get; set; } = default!;
        public DbSet<Area> Areas { get; set; } = default!;
        public DbSet<Retailer> Retailers { get; set; } = default!;
        public DbSet<RetailerSite> RetailerSites { get; set; } = default!;
        public DbSet<RetailerGroup> RetailerGroups { get; set; } = default!;
        public DbSet<Brand> Brands { get; set; } = default!;

        public DbSet<CustomerRetailerSite> CustomerRetailerSites { get; set; } = default!;

        public DbSet<Blog> Blogs { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Post> Posts { get; set; } = default!;


        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
        }
    }
}
