namespace LLPTest.Data.Retailers.Seeds
{
    public static class AreaSeed
    {
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
