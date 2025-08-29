namespace Phonebook.Domain.Entities
{
    public class Contact
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public IEnumerable<string> Addresses { get; set; } = new List<string>();

        public Contact() { }

        public Contact(string name, string phone, string email, DateTime? dateOfBirth, IEnumerable<string> addresses)
        {
            Name = name;
            Phone = phone;
            Email = email;
            DateOfBirth = dateOfBirth;
            Addresses = addresses;
        }
    }
}
