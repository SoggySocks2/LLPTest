using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Customers.Configuration
{
    public class CustomerRetailerSiteConfiguration : IEntityTypeConfiguration<CustomerRetailerSite>
    {
        public void Configure(EntityTypeBuilder<CustomerRetailerSite> builder)
        {
            builder.ToTable(nameof(CustomerRetailerSite));

            builder.HasOne(x => x.Customer).WithMany().OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(x => x.RetailerSite).WithMany().OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasKey(x => new { x.CustomerId, x.RetailerSiteId });
        }
    }
}
