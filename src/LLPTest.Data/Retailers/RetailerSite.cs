using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Retailers
{
    public class RetailerSite
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Retailer Retailer { get; private set; } = null!;
        public Guid RetailerId { get; private set; }

        public Brand Brand { get; private set; } = null!;
        public Guid BrandId { get; private set; }

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
    }
}
