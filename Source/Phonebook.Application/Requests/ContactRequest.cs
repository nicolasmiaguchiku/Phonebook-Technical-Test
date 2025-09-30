
using Mattioli.Configurations.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phonebook.Application.Requests
{
    public class ContactRequest
    {
        [FromQuery]
        public PageFilterRequest PageFilter { get; set; }

        [FromQuery]
        public IReadOnlyCollection<string>? Names { get; set; }

        [FromQuery]
        public string? ContactId { get; set; }

        public ContactRequest()
        {
            PageFilter = new PageFilterRequest
            {
                Page = 1,
                PageSize = 60
            };
        }
    }
}
