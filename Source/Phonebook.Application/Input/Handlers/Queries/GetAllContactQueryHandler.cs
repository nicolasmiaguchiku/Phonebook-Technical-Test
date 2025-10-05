using MediatR;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Interfaces;
using Mattioli.Configurations.Models;


namespace Phonebook.Application.Input.Handlers.Queries
{
    internal class GetAllContactQueryHandler(IContactRepository Repository) : IRequestHandler<GetAllContactsQuery, Result<IEnumerable<ContactResponse>>>
    {
        public async Task<Result<IEnumerable<ContactResponse>>> Handle(GetAllContactsQuery query, CancellationToken cancellationToken = default)
        {
            var domainFilters = new ContactFiltersBuilder
                .Builder(query.ContactRequest.PageFilter.Page, query.ContactRequest.PageFilter.PageSize)
                .WithNames(query.ContactRequest.Names!)
                .Build();

            return await Repository.GetAllContactsAsync(domainFilters, cancellationToken);
        }
    }
}