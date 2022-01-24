using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Retailers
{
    public class Area
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Region Region { get; private set; } = default!;
        public Guid RegionId { get; private set; }

        public IEnumerable<Retailer> Retailers => _retailers.AsEnumerable();
        private readonly List<Retailer> _retailers = new();

        public Area(string name)
        {
            Update(name);
        }

        [MemberNotNull(nameof(Name))]
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
