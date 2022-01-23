namespace LLPTest.Data.Retailers.Seeds
{
    public static class RetailerGroupSeed
    {
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
