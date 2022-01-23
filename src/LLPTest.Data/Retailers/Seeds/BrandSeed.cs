namespace LLPTest.Data.Retailers.Seeds
{
    public static class BrandSeed
    {
        public static List<Brand> Get(int from, int to)
        {
            var brands = new List<Brand>();

            for (var i = from; i <= to; i++)
            {
                brands.Add(new Brand($"Brand {i}"));
            }

            return brands;
        }
    }
}
