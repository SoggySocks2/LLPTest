using System.Text.Json;
using System.Text.Json.Serialization;

namespace LLPTest.Data.Blogs
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Blog> Blogs { get; } = new();

        public Author(string name)
        {
            Name = name;
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
