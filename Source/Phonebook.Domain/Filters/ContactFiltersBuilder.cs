
using MongoDB.Bson.Serialization.Serializers;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Phonebook.Domain.Filters
{
    public class ContactFiltersBuilder : PageFilter
    {
        public string? ContactsId { get; private set; }
        public IEnumerable<string>? Names { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
        public IEnumerable<string>? Addresses { get; private set; }
        public bool WithPagination { get; private set; }

        private ContactFiltersBuilder(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }

        public class Builder(int pageNumber = 1, int pageSize = 1)
        {
            private readonly ContactFiltersBuilder _filters = new(pageNumber, pageSize);

            public Builder WithFileIds(string contactsId)
            {
                if (!string.IsNullOrEmpty(contactsId))
                {
                    _filters.ContactsId = contactsId;
                }
                return this;
            }

            public Builder WithNames(IReadOnlyCollection<string> names)
            {
                if (names != null && names.Count > 0)
                {
                    _filters.Names = names;
                }

                return this;
            }

            public Builder WithPhoneNumber(string phoneNumber)
            {
                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    var phonesHandled = phoneNumber.Length >= 13 ? phoneNumber[3..] : phoneNumber;

                    if (phonesHandled.Length == 10 && !phoneNumber[..3].Contains("39"))
                    {
                        _filters.Phone = phonesHandled.Insert(2, "9");
                        return this;
                    }

                    _filters.Phone = phonesHandled;
                }

                return this;
            }
            public Builder WithEmail(string email)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    _filters.Email = email;
                }

                return this;
            }

            public Builder WithAddresses(IReadOnlyCollection<string> addresses)
            {
                if (addresses != null && addresses.Count == 0)
                {
                    _filters.Addresses = addresses;
                }

                return this;
            }

            public Builder WithPagination(bool paginate)
            {
                _filters.WithPagination = paginate;
                return this;
            }

            public ContactFiltersBuilder Build()
            {
                return _filters;
            }
        }
    }
}
