namespace LLPTest.Data.Retailers.Seeds
{
    public static class RetailerGroupSeed
    {
        public static List<RetailerGroup> GetTree(int count, int collectionCount, List<Guid> areaIds, List<Guid> brandIds)
        {
            var retailerGroups = Get(1, count);

            var retailers = RetailerSeed.GetTree(count * collectionCount, collectionCount, areaIds, brandIds);

            for (int i = 0; i < count; i++)
            {
                retailerGroups[i].AddRetailers(retailers.Skip(i * collectionCount).Take(collectionCount));
            }

            return retailerGroups;
        }

        public static List<RetailerGroup> Get(int from, int to)
        {
            var retailerGroups = new List<RetailerGroup>();

            for (var i = from; i <= to; i++)
            {
                retailerGroups.Add(new RetailerGroup($"RetailerGroup {i}"));
            }

            return retailerGroups;
        }
    }
}
