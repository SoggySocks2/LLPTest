using System.Diagnostics.CodeAnalysis;

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

        public Person Person { get; private set; }
        public ContactDetails ContactDetails { get; private set; }

        public Country Country { get; private set; } = null!;
        public Guid CountryId { get; private set; }

        public IEnumerable<Address> Addresses => _addresses.AsEnumerable();
        private readonly List<Address> _addresses = new();

        public Customer(Person person, ContactDetails contactDetails, Guid countryId)
        {
            if (countryId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(countryId));

            UpdatePerson(person);
            UpdateContactDetails(contactDetails);
            CountryId = countryId;
        }

        [MemberNotNull(nameof(Person))]
        private void UpdatePerson(Person person)
        {
            _ = person ?? throw new ArgumentNullException(nameof(person));

            if (!person.Equals(Person))
            {
                Person = person;
            }
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

            var address = Addresses.FirstOrDefault(x=>x.Id == addressId);
            if (address is null) throw new KeyNotFoundException(nameof(addressId));

            _addresses.Remove(address);
        }
    }
}
