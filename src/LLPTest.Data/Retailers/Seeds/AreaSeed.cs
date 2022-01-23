namespace LLPTest.Data.Retailers.Seeds
{
    public static class AreaSeed
    {
        public static List<Area> GetTree(List<Guid> retailerGroupIds, List<Guid> brandIds, int count, int collectionCount)
        {
            var areas = Get(1, count);

            var retailers = RetailerSeed.GetTree(retailerGroupIds, brandIds, count * collectionCount, collectionCount);

            for (int i = 1; i <= count; i++)
            {
                areas[i - 1].AddRetailers(retailers.Skip((i * collectionCount) - collectionCount).Take(collectionCount));
            }

            return areas;
        }

        public static List<Area> Get(int from, int to)
        {
            var areas = new List<Area>();

            for (var i = from; i <= to; i++)
            {
                areas.Add(new Area($"Area {i}"));
            }

            return areas;
        }
    }
}
