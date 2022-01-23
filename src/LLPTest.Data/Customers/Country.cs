using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LLPTest.Data.Customers
{
    public class Country
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        [JsonIgnore]
        public IEnumerable<Customer> Customers => _customers.AsEnumerable();
        private readonly List<Customer> _customers = new();

        public Country(string name)
        {
            Update(name);
        }

        [MemberNotNull(nameof(Name))]
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

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
