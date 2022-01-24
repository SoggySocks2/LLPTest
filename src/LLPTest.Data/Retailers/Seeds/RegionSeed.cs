namespace LLPTest.Data.Retailers.Seeds
{
    public static class RegionSeed
    {
        public static List<Region> GetTree(int count, int collectionCount)
        {
            var regions = Get(1, count);

            var areas = AreaSeed.Get(1, count * collectionCount);

            for (int i = 0; i < count; i++)
            {
                regions[i].AddAreas(areas.Skip(i * collectionCount).Take(collectionCount));
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
