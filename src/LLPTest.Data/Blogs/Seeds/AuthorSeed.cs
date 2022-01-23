namespace LLPTest.Data.Blogs.Seeds
{
    public static class AuthorSeed
    {
        public static List<Author> Get(int count)
        {
            var authors = new List<Author>();

            for (var i = 1; i <= count; i++)
            {
                authors.Add(new Author($"Author {i}"));
            }

            authors.Reverse();
            return authors;
        }
    }
}
