using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Customers
{
    public class Address
    {
        public Guid Id { get; private set; }
        public string Street { get; private set; }

        public Guid CustomerId { get; private set; }

        public Address(string street)
        {
            Update(street);
        }

        [MemberNotNull(nameof(Street))]
        public void Update(string street)
        {
            if (string.IsNullOrEmpty(street)) throw new ArgumentNullException(nameof(street));

            Street = street;
        }
    }
}
