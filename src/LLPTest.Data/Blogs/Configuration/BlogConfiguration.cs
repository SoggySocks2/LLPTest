using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Blogs.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable(nameof(Blog));

            builder.HasOne(x => x.BlogImage).WithOne().HasForeignKey<BlogImage>();

            builder.HasKey(x => x.Id);
        }
    }
}
