namespace LLPTest.Data.Retailers.Seeds
{
    public static class RetailerSeed
    {
        public static List<Retailer> GetTree(List<Guid> retailerGroupIds, List<Guid> brandIds, int count, int collectionCount)
        {
            var retailers = Get(retailerGroupIds, 1, count);

            var retailerSites = RetailerSiteSeed.Get(brandIds, 1, count * collectionCount);

            for (int i = 1; i <= count; i++)
            {
                retailers[i - 1].AddRetailerSites(retailerSites.Skip((i * collectionCount) - collectionCount).Take(collectionCount));
            }

            return retailers;
        }

        public static List<Retailer> Get(List<Guid> retailerGroupIds, int from, int to)
        {
            var retailers = new List<Retailer>();

            for (var i = from; i <= to; i++)
            {
                retailers.Add(new Retailer(retailerGroupIds[(i - 1) % retailerGroupIds.Count], $"Retailer {i}"));
            }

            return retailers;
        }
    }
}
