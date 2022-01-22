using System.Diagnostics.CodeAnalysis;

namespace LLPTest.Data.Customers
{
    public class Gender
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }

        public Gender(string description)
        {
            Update(description);
        }

        [MemberNotNull(nameof(Description))]
        public void Update(string description)
        {
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));

            Description = description;
        }
    }
}
