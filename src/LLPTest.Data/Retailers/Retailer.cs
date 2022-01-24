using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Retailers
{
    public class Retailer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Area Area { get; private set; } = null!;
        public Guid AreaId { get; private set; }

        public RetailerGroup RetailerGroup { get; private set; } = null!;
        public Guid RetailerGroupId { get; private set; }

        public IEnumerable<RetailerSite> RetailerSites => _retailerSites.AsEnumerable();
        private readonly List<RetailerSite> _retailerSites = new();

        public Retailer(Guid areaId, string name)
        {
            if (areaId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(areaId));

            Update(name);
            AreaId = areaId;
        }

        [MemberNotNull(nameof(Name))]
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void AddRetailerSite(RetailerSite retailerSite)
        {
            _ = retailerSite ?? throw new ArgumentNullException(nameof(retailerSite));

            _retailerSites.Add(retailerSite);
        }

        public void AddRetailerSites(IEnumerable<RetailerSite> retailerSites)
        {
            foreach (var retailerSite in retailerSites)
            {
                AddRetailerSite(retailerSite);
            }
        }
    }
}
