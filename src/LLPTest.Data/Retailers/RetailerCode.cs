using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Retailers
{
    public class RetailerCode
    {
        public Guid Id { get; set; }
        public string Code { get; private set; }

        public RetailerSite RetailerSite { get; private set; } = null!;
        public Guid RetailerSiteId { get; private set; }

        public RetailerCode(string code)
        {
            Update(code);
        }

        [MemberNotNull(nameof(Code))]
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Code = name;
        }
    }
}
