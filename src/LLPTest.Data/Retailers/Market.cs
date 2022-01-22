using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Retailers
{
    public class Market
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public IEnumerable<Region> Regions => _regions.AsEnumerable();
        private readonly List<Region> _regions = new();

        public Market(string name)
        {
            Update(name);
        }

        [MemberNotNull(nameof(Name))]
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void AddRegion(Region region)
        {
            _ = region ?? throw new ArgumentNullException(nameof(region));

            _regions.Add(region);
        }
    }
}
