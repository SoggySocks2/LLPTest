using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Blogs.Configuration
{
    public class BlogImageConfiguration : IEntityTypeConfiguration<BlogImage>
    {
        public void Configure(EntityTypeBuilder<BlogImage> builder)
        {
            builder.ToTable(nameof(BlogImage));

            builder.HasKey(x => x.Id);
        }
    }
}
