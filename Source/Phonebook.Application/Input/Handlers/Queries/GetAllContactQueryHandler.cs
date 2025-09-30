using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;


namespace Phonebook.Application.Input.Handlers.Queries
{
    internal class GetAllContactQueryHandler(IContactRepository Repository) : IRequestHandler<GetAllContactsQuery, ResultData<IEnumerable<Contact>>>
    {
        public async Task<ResultData<IEnumerable<Contact>>> Handle(GetAllContactsQuery query, CancellationToken cancellationToken = default)
        {
            var domainFilters = new ContactFiltersBuilder
                .Builder(query.ContactRequest.PageFilter.Page, query.ContactRequest.PageFilter.PageSize)
                .WithNames(query.ContactRequest.Names!)
                .Build();

            var result = await Repository.GetAllContactsAsync(domainFilters, cancellationToken);
            return result;
        }
    }
}