using MediatR;
using Phonebook.Application.Queries.GetAllContacts;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Shared.Results;


public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, ResultData<IEnumerable<Contact>>>
{
    private readonly IContactRepository _repositoryContact;
    public GetAllContactsHandler(IContactRepository repositoryContact)
    {
        _repositoryContact = repositoryContact;
    }

    public async Task<ResultData<IEnumerable<Contact>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        return await _repositoryContact.GetAllContactsAsync();
    }
}