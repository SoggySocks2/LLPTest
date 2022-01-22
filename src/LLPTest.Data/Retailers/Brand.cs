using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Retailers
{
    public class Brand
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public IEnumerable<RetailerSite> RetailerSites => _retailerSites.AsEnumerable();
        private readonly List<RetailerSite> _retailerSites = new();

        public Brand(string name)
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
