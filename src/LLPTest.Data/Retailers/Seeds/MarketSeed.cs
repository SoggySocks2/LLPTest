namespace LLPTest.Data.Retailers.Seeds
{
    public static class MarketSeed
    {
        public static List<Market> GetTree(int count, int collectionCount)
        {
            var markets = Get(1, count);

            var regions = RegionSeed.GetTree(count * collectionCount, collectionCount);

            for (int i = 0; i < count; i++)
            {
                markets[i].AddRegions(regions.Skip(i * collectionCount).Take(collectionCount));
            }

            return markets;
        }

        public static List<Market> Get(int from, int to)
        {
            var markets = new List<Market>();

            for (var i = from; i <= to; i++)
            {
                markets.Add(new Market($"Market {i}"));
            }

            return markets;
        }
    }
}
