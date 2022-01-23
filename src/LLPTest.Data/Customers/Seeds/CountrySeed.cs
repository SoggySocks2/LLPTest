namespace LLPTest.Data.Customers.Seeds
{
    public static class CountrySeed
    {
        public static List<Country> Get(int from, int to)
        {
            var countries = new List<Country>();

            for (var i = from; i <= to; i++)
            {
                countries.Add(new Country($"Country {i}"));
            }

            return countries;
        }
    }
}
