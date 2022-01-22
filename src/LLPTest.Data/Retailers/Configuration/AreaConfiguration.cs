using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Retailers.Configuration
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable(nameof(Area));

            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);

            builder.HasKey(x => x.Id);
        }
    }
}
