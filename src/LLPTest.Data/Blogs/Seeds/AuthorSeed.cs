namespace LLPTest.Data.Blogs.Seeds
{
    public static class AuthorSeed
    {
        public static List<Author> Get(int from, int to)
        {
            var authors = new List<Author>();

            for (var i = from; i <= to; i++)
            {
                authors.Add(new Author($"Author {i}"));
            }

            return authors;
        }
    }
}
