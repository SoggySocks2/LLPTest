using System.Globalization;

namespace LLPTest.Data.Blogs.Seeds
{
    public static class BlogSeed
    {
        public static List<Blog> Get(List<Author> authors, int count)
        {
            var blogs = new List<Blog>();

            for (var i = 1; i <= count; i++)
            {
                blogs.Add(new Blog($"Blog {i}"));
                blogs[i-1].Author = authors[(i-1) % authors.Count];
            }

            blogs.Reverse();
            return blogs;
        }
    }
}
