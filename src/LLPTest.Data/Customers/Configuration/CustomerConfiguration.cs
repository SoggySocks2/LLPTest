using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LLPTest.Data.Customers.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.OwnsOne(x => x.Person, cb =>
            {
                cb.Property(p => p.GenderId);
                cb.Property(p => p.FirstName).IsRequired().HasColumnName(nameof(Person.FirstName)).HasMaxLength(250);
                cb.Property(p => p.LastName).HasColumnName(nameof(Person.LastName)).HasMaxLength(250);
            });

            builder.OwnsOne(x => x.ContactDetails, cb =>
            {
                cb.Property(cd => cd.Email).IsRequired().HasColumnName(nameof(ContactDetails.Email)).HasMaxLength(250);
            });

            // TODO: Check if it works without it [fatii, 1/22/2022]
            builder.Metadata.FindNavigation(nameof(Customer.Addresses)).SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);
        }
    }
}
