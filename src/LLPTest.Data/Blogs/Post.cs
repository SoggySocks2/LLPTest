using System.Text.Json;
using System.Text.Json.Serialization;

namespace LLPTest.Data.Blogs
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [JsonIgnore]
        public Blog Blog { get; set; } = default!;
        public int BlogId { get; set; }

        public Post(string title)
        {
            Title = title;
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
