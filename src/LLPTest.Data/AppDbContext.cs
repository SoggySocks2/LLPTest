using LLPTest.Data.Customers;
using LLPTest.Data.Customers.Configuration;
using LLPTest.Data.Retailers;
using Microsoft.EntityFrameworkCore;

namespace LLPTest.Data
{
    public class AppDbContext : DbContext
    {
        private readonly static string _connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=LLPTest;Integrated Security=SSPI;ConnectRetryCount=0;";

        public DbSet<Gender> Genders { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Market> Markets { get; set; } = null!;
        public DbSet<Region> Regions { get; set; } = null!;
        public DbSet<Area> Areas { get; set; } = null!;
        public DbSet<Retailer> Retailers { get; set; } = null!;
        public DbSet<RetailerSite> RetailerSites { get; set; } = null!;
        public DbSet<RetailerGroup> RetailerGroups { get; set; } = null!;
        public DbSet<Brand> Brands { get; set; } = null!;

        public DbSet<CustomerRetailerSite> CustomerRetailerSites { get; set; } = null!;

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
