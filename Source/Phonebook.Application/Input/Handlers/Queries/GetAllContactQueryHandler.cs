using MediatR;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;


namespace Phonebook.Application.Input.Handlers.Queries
{
    internal class GetAllContactQueryHandler(IContactRepository Repository) : IRequestHandler<GetAllContactsQuery, ResultData<IEnumerable<ContactResponse>>>
    {
        public async Task<ResultData<IEnumerable<ContactResponse>>> Handle(GetAllContactsQuery query, CancellationToken cancellationToken = default)
        {
            var domainFilters = new ContactFiltersBuilder
                .Builder(query.ContactRequest.PageFilter.Page, query.ContactRequest.PageFilter.PageSize)
                .WithNames(query.ContactRequest.Names!)
                .Build();

            return await Repository.GetAllContactsAsync(domainFilters, cancellationToken);
        }
    }
}