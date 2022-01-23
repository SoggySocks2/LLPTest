namespace LLPTest.Data.Retailers.Seeds
{
    public static class RetailerSiteSeed
    {
        public static List<RetailerSite> Get(List<Guid> brandIds, int from, int to)
        {
            var retailerSites = new List<RetailerSite>();

            for (var i = from; i <= to; i++)
            {
                retailerSites.Add(new RetailerSite(brandIds[(i - 1) % brandIds.Count], $"RetailerSite {i}"));
            }

            return retailerSites;
        }
    }
}
