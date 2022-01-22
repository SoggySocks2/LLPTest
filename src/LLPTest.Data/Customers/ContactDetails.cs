namespace LLPTest.Data.Customers
{
    public class ContactDetails : ValueObject
    {
        public string Email { get; private set; }

        public ContactDetails(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
            
            Email = email;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Email;
        }
    }
}
