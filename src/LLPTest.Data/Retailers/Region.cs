using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Retailers
{
    public class Region
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Market Market { get; private set; } = default!;
        public Guid MarketId { get; private set; }

        public IEnumerable<Area> Areas => _areas.AsEnumerable();
        private readonly List<Area> _areas = new();

        public Region(string name)
        {
            Update(name);
        }

        [MemberNotNull(nameof(Name))]
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void AddArea(Area area)
        {
            _ = area ?? throw new ArgumentNullException(nameof(area));

            _areas.Add(area);
        }

        public void AddAreas(IEnumerable<Area> areas)
        {
            foreach (var area in areas)
            {
                AddArea(area);
            }
        }
    }
}
