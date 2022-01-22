using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Retailers.Configuration
{
    public class RetailerGroupConfiguration : IEntityTypeConfiguration<RetailerGroup>
    {
        public void Configure(EntityTypeBuilder<RetailerGroup> builder)
        {
            builder.ToTable(nameof(RetailerGroup));

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

            builder.HasKey(x => x.Id);
        }
    }
}
