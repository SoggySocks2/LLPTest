using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Retailers
{
    public class RetailerSite
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Retailer Retailer { get; private set; } = default!;
        public Guid RetailerId { get; private set; }

        public Brand Brand { get; private set; } = default!;
        public Guid BrandId { get; private set; }

        public IEnumerable<RetailerCode> RetailerCodes => _retailerCodes.AsEnumerable();
        private readonly List<RetailerCode> _retailerCodes = new();

        public RetailerSite(Guid brandId, string name)
        {
            if (brandId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(brandId));

            Update(name);
            BrandId = brandId;
        }

        [MemberNotNull(nameof(Name))]
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void AddRetailerCode(RetailerCode retailerCode)
        {
            _ = retailerCode ?? throw new ArgumentNullException(nameof(retailerCode));

            _retailerCodes.Add(retailerCode);
        }

        public void AddRetailerCode(IEnumerable<RetailerCode> retailerCodes)
        {
            foreach (var retailerCode in retailerCodes)
            {
                AddRetailerCode(retailerCode);
            }
        }
    }
}
