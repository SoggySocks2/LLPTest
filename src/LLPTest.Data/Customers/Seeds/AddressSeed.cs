namespace LLPTest.Data.Customers.Seeds
{
    public static class AddressSeed
    {
        public static List<Address> Get(int from, int to)
        {
            var addresses = new List<Address>();

            for (var i = from; i <= to; i++)
            {
                addresses.Add(new Address($"Street {i}"));
            }

            return addresses;
        }
    }
}
