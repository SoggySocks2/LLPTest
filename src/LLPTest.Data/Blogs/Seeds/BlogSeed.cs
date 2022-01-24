namespace LLPTest.Data.Blogs.Seeds
{
    public static class BlogSeed
    {
        public static List<Blog> Get(List<int> authorIds, int from, int to)
        {
            var blogs = new List<Blog>();

            for (var i = from; i <= to; i++)
            {
                var blog = new Blog($"Blog {i}");
                blog.AuthorId = authorIds[(i - 1) % authorIds.Count];
                blogs.Add(blog);
            }

            return blogs;
        }
    }
}
