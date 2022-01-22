using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Customers
{
    public class Country
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

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
    }
}
