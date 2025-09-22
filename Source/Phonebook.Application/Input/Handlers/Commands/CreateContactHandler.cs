using MediatR;
using Phonebook.Domain.Results;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using FluentValidation;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public sealed class CreateContactHandler(IContactRepository Repository) : IRequestHandler<CreateContactCommand, ResultData<Contact>>
    {
        public async Task<ResultData<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact(request.Name, request.Phone, request.Email, request.DateOfBirth);
            contact.AddAddresses(request.Addresses);

            var result = await Repository.CreateContactAsync(contact);

            return result;
        }
    }
}
