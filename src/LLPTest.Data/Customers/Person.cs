namespace LLPTest.Data.Customers
{
    public class Person : ValueObject
    {
        public string FirstName { get; private set; }
        public string? LastName { get; private set; }

        public Gender? Gender { get; private set; }
        public Guid? GenderId { get; private set; }

        public Person(string firstName, string? lastName, Guid? genderId)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
            if (genderId is not null && genderId.Equals(Guid.Empty)) throw new ArgumentException(null, nameof(genderId));

            FirstName = firstName;
            LastName = lastName;
            GenderId = genderId;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
            yield return GenderId;
        }
    }
}
