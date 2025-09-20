using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;


namespace Phonebook.Application.Input.Handlers.Queries
{
    internal class GetContactByIdHandler(IContactRepository Repository) : IRequestHandler<GetContactByIdQuery, ResultData<Contact>>
    {
        public async Task<ResultData<Contact>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await Repository.GetContactByIdAsync(request.Id);
            return result;
        }
    }
}
