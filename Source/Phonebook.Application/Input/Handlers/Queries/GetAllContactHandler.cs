using MediatR;
using Phonebook.Application.Handlers.Queries;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;


public class GetAllContactsHandler(IContactRepository Repository): IRequestHandler<GetAllContactsQuery, ResultData<IEnumerable<Contact>>>
{
    public async Task<ResultData<IEnumerable<Contact>>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        var result = await Repository.GetAllContactsAsync();
        return result;
    }
}