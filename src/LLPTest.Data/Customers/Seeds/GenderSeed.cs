namespace LLPTest.Data.Customers.Seeds
{
    public static class GenderSeed
    {
        public static List<Gender> Get(int from, int to)
        {
            var genders = new List<Gender>();

            for (var i = from; i <= to; i++)
            {
                genders.Add(new Gender($"Gender {i}"));
            }

            return genders;
        }
    }
}
