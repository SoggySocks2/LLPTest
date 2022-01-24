namespace LLPTest.Data.Customers.Seeds
{
    public static class CustomerSeed
    {
        public static List<Customer> GetTree(int count, int collectionCount, List<Guid> genderIds, List<Guid> countryIds)
        {
            var customers = new List<Customer>();

            var addresses = AddressSeed.Get(1, count * collectionCount);

            for (var i = 1; i <= count; i++)
            {
                var customer = new Customer
                (
                    new Person($"Firstname {i}", $"Lastname {i}", genderIds[(i - 1) % genderIds.Count]),
                    new ContactDetails($"Email_{i}@local"),
                    countryIds[(i - 1) % countryIds.Count]
                );
                customer.AddAddresses(addresses.Skip((i - 1) * collectionCount).Take(collectionCount));
                customers.Add(customer);
            }

            return customers;
        }
    }
}
