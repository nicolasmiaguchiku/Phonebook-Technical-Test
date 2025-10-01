
using Mattioli.Configurations.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phonebook.Domain.Dtos.Requests
{
    public class GetContactRequest
    {
        [FromQuery]
        public PageFilterRequest PageFilter { get; set; }

        [FromQuery]
        public IReadOnlyCollection<string>? Names { get; set; }

        [FromQuery]
        public string? ContactId { get; set; }

        public GetContactRequest()
        {
            PageFilter = new PageFilterRequest
            {
                Page = 1,
                PageSize = 60
            };
        }
    }
}
