using MediatR;
using Phonebook.Application.Queries.GetAllContacts;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;


public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<Contact>>
{
    private readonly IContactRepository _repositoryContact;
    public GetAllContactsHandler(IContactRepository repositoryContact)
    {
        _repositoryContact = repositoryContact;
    }

    public async Task<IEnumerable<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        return await _repositoryContact.GetAllContactsAsync();
    }
}