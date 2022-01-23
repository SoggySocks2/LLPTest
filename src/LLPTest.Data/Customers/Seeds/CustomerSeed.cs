namespace LLPTest.Data.Customers.Seeds
{
    public static class CustomerSeed
    {
        public static List<Customer> Get(List<Gender> genders, List<Country> countries, int count, int collectionCount)
        {
            var genderIds = genders.Select(x=>x.Id).ToList();
            var countriesIds = countries.Select(x=>x.Id).ToList();
            var addresses = AddressSeed.Get(1, count * collectionCount);

            var customers = new List<Customer>();

            for (var i = 1; i <= count; i++)
            {
                customers.Add(new Customer
                (
                    new Person($"Firstname {i}", $"Lastname {i}", genderIds[(i - 1) % genderIds.Count]),
                    new ContactDetails($"Email_{i}@local"),
                    countriesIds[(i - 1) % countriesIds.Count]
                ));
                customers[i - 1].AddAddresses(addresses.Skip((i * collectionCount) - collectionCount).Take(collectionCount));
            }

            return customers;
        }
    }
}
