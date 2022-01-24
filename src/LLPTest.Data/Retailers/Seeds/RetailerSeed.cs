namespace LLPTest.Data.Retailers.Seeds
{
    public static class RetailerSeed
    {
        public static List<Retailer> GetTree(int count, int collectionCount, List<Guid> retailerGroupIds, List<Guid> brandIds)
        {
            var retailers = Get(1, count, retailerGroupIds);

            var retailerSites = RetailerSiteSeed.Get(1, count * collectionCount, brandIds);

            for (int i = 0; i < count; i++)
            {
                retailers[i].AddRetailerSites(retailerSites.Skip(i * collectionCount).Take(collectionCount));
            }

            return retailers;
        }

        public static List<Retailer> Get(int from, int to, List<Guid> retailerGroupIds)
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
