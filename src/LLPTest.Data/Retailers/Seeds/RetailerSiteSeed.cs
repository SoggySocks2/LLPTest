namespace LLPTest.Data.Retailers.Seeds
{
    public static class RetailerSiteSeed
    {
        public static List<RetailerSite> Get(int from, int to, List<Guid> brandIds)
        {
            var retailerSites = new List<RetailerSite>();

            for (var i = from; i <= to; i++)
            {
                var retailerSite = new RetailerSite(brandIds[(i - 1) % brandIds.Count], $"RetailerSite {i}");

                // Add two static codes, not important value.
                retailerSite.AddRetailerCode(new RetailerCode($"RetailerCode {i}_1"));
                retailerSite.AddRetailerCode(new RetailerCode($"RetailerCode {i}_2"));
                retailerSites.Add(retailerSite);
            }

            return retailerSites;
        }
    }
}
