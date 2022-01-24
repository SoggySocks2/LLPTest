namespace LLPTest.Data.Retailers.Seeds
{
    public static class RetailerCodeSeed
    {
        public static List<RetailerCode> Get(int from, int to)
        {
            var retailerCodes = new List<RetailerCode>();

            for (var i = from; i <= to; i++)
            {
                retailerCodes.Add(new RetailerCode($"RetailerCode {i}"));
            }

            return retailerCodes;
        }
    }
}
