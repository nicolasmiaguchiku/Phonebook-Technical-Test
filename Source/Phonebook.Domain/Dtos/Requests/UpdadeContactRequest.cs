namespace Phonebook.Domain.Dtos.Requests
{
    public record UpdadeContactRequest
    {
        public required string ContactId { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required IEnumerable<string> Addresses { get; set; }

        public Builder ToBuilder() => new()
        {
            ContactId = ContactId,
            Name = Name,
            Phone = Phone,
            Email = Email,
            DateOfBirth = DateOfBirth,
            Addresses = Addresses
        };

        public sealed class Builder()
        {
            internal string? ContactId { get; set; }
            internal string? Name { get; set; }
            internal string? Phone { get; set; }
            internal string? Email { get; set; }
            internal DateTime DateOfBirth { get; set; }
            internal IEnumerable<string>? Addresses { get; set; }
            public Builder SetContactId(string contacId) { ContactId = contacId; return this; }
            public Builder SetName(string name) { Name = name; return this; }
            public Builder SetPhone(string phone) { Phone = phone; return this; }
            public Builder SetEmail(string email) { Email = email; return this; }
            public Builder SetDateOfBirth(DateTime dateOfBirth) { DateOfBirth = dateOfBirth; return this; }
            public Builder SetAddresses(IEnumerable<string> addresses)
            {
                if (addresses != null && addresses.Any())
                {
                    Addresses = addresses;
                }

                return this;
            }

            public UpdadeContactRequest Build()
            {
                return new UpdadeContactRequest
                {
                    ContactId = ContactId!,
                    Name = Name!,
                    Phone = Phone!,
                    Email = Email!,
                    DateOfBirth = DateOfBirth,
                    Addresses = Addresses!
                };
            }
        }
    }
}
