using MediatR;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;

namespace Phonebook.Application.Input.Handlers.Commands
{
    public sealed class CreateContactHandler(IContactRepository Repository) 
        : IRequestHandler<CreateContactCommand, ResultData<ContactResponse>>
    {
        public async Task<ResultData<ContactResponse>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = request.AddContactRequest
                .ToBuilder()
                .SetName(request.AddContactRequest.Name)
                .SetPhone(request.AddContactRequest.Phone)
                .SetEmail(request.AddContactRequest.Email)
                .SetDateOfBirth(request.AddContactRequest.DateOfBirth)
                .SetAddresses(request.AddContactRequest.Addresses)
                .Build();

            return await Repository.CreateContactAsync(contact);
        }
    }
}
