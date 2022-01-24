namespace LLPTest.Data.Blogs.Seeds
{
    public static class PostSeed
    {
        public static List<Post> Get(List<int> blogIds, int from, int to)
        {
            var posts = new List<Post>();

            for (var i = from; i <= to; i++)
            {
                var post = new Post($"Post {i}");
                post.BlogId = blogIds[(i - 1) % blogIds.Count];
                posts.Add(post);
            }

            posts.Reverse();
            return posts;
        }
    }
}
