using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;


namespace Phonebook.Application.Input.Handlers.Queries
{
    internal class GetAllContactHandler(IContactRepository Repository) : IRequestHandler<GetAllContactsQuery, ResultData<IEnumerable<Contact>>>
    {
        public async Task<ResultData<IEnumerable<Contact>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetAllContactsAsync();
            return result;
        }
    }
}