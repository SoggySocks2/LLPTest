using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Retailers.Configuration
{
    public class RetailerCodeConfiguration : IEntityTypeConfiguration<RetailerCode>
    {
        public void Configure(EntityTypeBuilder<RetailerCode> builder)
        {
            builder.ToTable(nameof(RetailerCode));

            builder.Property(x => x.Code).IsRequired().HasMaxLength(250);

            builder.HasKey(x => x.Id);
        }
    }
}
