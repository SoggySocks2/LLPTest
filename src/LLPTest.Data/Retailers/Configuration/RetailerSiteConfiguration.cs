using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Retailers.Configuration
{
    public class RetailerSiteConfiguration : IEntityTypeConfiguration<RetailerSite>
    {
        public void Configure(EntityTypeBuilder<RetailerSite> builder)
        {
            builder.ToTable(nameof(RetailerSite));

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

            builder.HasKey(x => x.Id);
        }
    }
}
