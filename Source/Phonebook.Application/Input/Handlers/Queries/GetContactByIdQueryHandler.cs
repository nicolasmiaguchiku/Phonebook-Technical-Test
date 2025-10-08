using MediatR;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Interfaces;
using Mattioli.Configurations.Models;

namespace Phonebook.Application.Input.Handlers.Queries
{
    internal class GetContactByIdQueryHandler(IContactRepository Repository)
        : IRequestHandler<GetContactByIdQuery, Result<ContactResponse>>
    {
        public async Task<Result<ContactResponse>> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
        {
            var domainFilters = new ContactFiltersBuilder
                .Builder(query.ContactRequest.PageFilter.Page, query.ContactRequest.PageFilter.PageSize)
                .WithFileIds(query.ContactRequest.ContactId!)
                .Build();

            return await Repository.GetContactByIdAsync(domainFilters, cancellationToken);

        }
    }
}
