using System.Text.Json;

namespace LLPTest.Data.Blogs
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Author Author { get; set; } = default!;
        public int AuthorId { get; set; }

        public List<Post> Posts { get; } = new();

        public Blog(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this, _jsonOptions);
        }

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
    }
}
