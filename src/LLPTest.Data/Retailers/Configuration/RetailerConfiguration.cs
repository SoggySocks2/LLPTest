using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Retailers.Configuration
{
    public class RetailerConfiguration : IEntityTypeConfiguration<Retailer>
    {
        public void Configure(EntityTypeBuilder<Retailer> builder)
        {
            builder.ToTable(nameof(Retailer));

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

            builder.HasKey(x => x.Id);
        }
    }
}
