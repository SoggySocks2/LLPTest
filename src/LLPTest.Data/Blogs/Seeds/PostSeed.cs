namespace LLPTest.Data.Blogs.Seeds
{
    public static class PostSeed
    {
        public static List<Post> Get(List<Blog> blogs, int from, int to)
        {
            var posts = new List<Post>();

            for (var i = from; i <= to; i++)
            {
                var post = new Post($"Post {i}");
                posts.Add(post);
                post.Blog = blogs[(i - 1) % blogs.Count];
            }

            posts.Reverse();
            return posts;
        }
    }
}
