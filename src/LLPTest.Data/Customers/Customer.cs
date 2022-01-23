using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace LLPTest.Data.Customers
{
    public class Customer
    {
        private Customer()
        {
            Person = default!;
            ContactDetails = default!;
        }

        public Guid Id { get; private set; }

        public Person Person { get; }
        public ContactDetails ContactDetails { get; private set; }

        public Country Country { get; private set; } = null!;
        public Guid CountryId { get; private set; }

        public IEnumerable<Address> Addresses => _addresses.AsEnumerable();
        private readonly List<Address> _addresses = new();

        public Customer(Person person, ContactDetails contactDetails, Guid countryId)
        {
            _ = person ?? throw new ArgumentNullException(nameof(person));
            if (countryId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(countryId));

            Person = person;
            CountryId = countryId;
            UpdateContactDetails(contactDetails);
        }

        [MemberNotNull(nameof(ContactDetails))]
        private void UpdateContactDetails(ContactDetails contactDetails)
        {
            _ = contactDetails ?? throw new ArgumentNullException(nameof(contactDetails));

            if (ContactDetails is null || !contactDetails.Equals(ContactDetails))
            {
                ContactDetails = contactDetails;
            }
        }

        public void AddAddress(Address address)
        {
            _ = address ?? throw new ArgumentNullException(nameof(address));

            _addresses.Add(address);
        }

        public void AddAddresses(IEnumerable<Address> addresses)
        {
            foreach (var address in addresses)
            {
                AddAddress(address);
            }
        }

        public void UpdateAddress(Guid addressId, string street)
        {
            if (addressId.Equals(Guid.Empty)) throw new ArgumentException(null, nameof(addressId));

            var address = Addresses.FirstOrDefault(x => x.Id == addressId);
            if (address is null) throw new KeyNotFoundException(nameof(addressId));

            address.Update(street);
        }

        public void RemoveAddress(Guid addressId)
        {
            if (addressId.Equals(Guid.Empty)) throw new ArgumentException(null, nameof(addressId));

            var address = Addresses.FirstOrDefault(x => x.Id == addressId);
            if (address is null) throw new KeyNotFoundException(nameof(addressId));

            _addresses.Remove(address);
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, _jsonOptions);
        }

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
    }
}
