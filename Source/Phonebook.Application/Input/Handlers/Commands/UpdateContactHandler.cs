using MediatR;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;
using Phonebook.Application.Input.Handlers.Commands;
using Phonebook.Domain.Dtos.Response;
using Phonebook.Domain.Filters;
using Phonebook.Domain.Dtos.Requests;

public class UpdateContactCommandHandler(IContactRepository Repository)
    : IRequestHandler<UpdateContactCommand, ResultData<ContactResponse>>
{
    public async Task<ResultData<ContactResponse>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var filter = new ContactFiltersBuilder.Builder()
            .WithFileIds(request.ContactRequest.ContactId)
            .Build();

        var contactEntity = await Repository.GetContactByIdAsync(filter, cancellationToken);

        if (contactEntity == null)
        {
            return ResultData<ContactResponse>.Failure("Contato não encontrado");
        }
        else
        {
            var contactUpdate = new UpdadeContactRequest.Builder()
                .SetName(request.ContactRequest.Name)
                .SetPhone(request.ContactRequest.Phone)
                .SetDateOfBirth(request.ContactRequest.DateOfBirth)
                .SetEmail(request.ContactRequest.Email)
                .SetAddresses(request.ContactRequest.Addresses)
                .Build();

            return await Repository.UpdadeContactAsync(contactUpdate);
        }
    }
}
