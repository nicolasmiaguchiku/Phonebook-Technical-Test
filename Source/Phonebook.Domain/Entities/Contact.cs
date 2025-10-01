using Mattioli.Configurations.Http;
using Phonebook.Domain.Filters;

namespace Phonebook.Domain.Entities
{
    public class Contact
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }

        private List<string> _addresses = new();

        public IEnumerable<string> Addresses => _addresses;

        public Contact() { }

        public Contact(string name, string phone, string email, DateTime dateOfBirth)
        {
            Name = name;
            Phone = phone;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public void AddAddresses(IEnumerable<string> addresses)
        {
            _addresses.AddRange(addresses);
        }
    }
}
