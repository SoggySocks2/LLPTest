using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Retailers.Configuration
{
    public class MarketConfiguration : IEntityTypeConfiguration<Market>
    {
        public void Configure(EntityTypeBuilder<Market> builder)
        {
            builder.ToTable(nameof(Market));

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

            builder.HasKey(x => x.Id);
        }
    }
}
