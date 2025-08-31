using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Shared.Results;

namespace Phonebook.Application.Queries.GetContactById
{
    internal class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ResultData<Contact>>
    {

        private readonly IContactRepository _repositoryContact;

        public GetContactByIdHandler(IContactRepository repositoryContact)
        {
            _repositoryContact = repositoryContact;
        }

        public async Task<ResultData<Contact>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryContact.GetContactByIdAsync(request.id);
        }
    }
}
