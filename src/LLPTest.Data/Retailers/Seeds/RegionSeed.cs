namespace LLPTest.Data.Retailers.Seeds
{
    public static class RegionSeed
    {
        public static List<Region> GetTree(List<Guid> retailerGroupIds, List<Guid> brandIds, int count, int collectionCount)
        {
            var regions = Get(1, count);

            var areas = AreaSeed.GetTree(retailerGroupIds, brandIds, count * collectionCount, collectionCount);

            for (int i = 1; i <= count; i++)
            {
                regions[i - 1].AddAreas(areas.Skip((i * collectionCount) - collectionCount).Take(collectionCount));
            }

            return regions;
        }

        public static List<Region> Get(int from, int to)
        {
            var regions = new List<Region>();

            for (var i = from; i <= to; i++)
            {
                regions.Add(new Region($"Region {i}"));
            }

            return regions;
        }
    }
}
