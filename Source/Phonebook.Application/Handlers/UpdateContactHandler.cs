using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Shared.Results;
using Phonebook.Application.Commands;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ResultData<Contact>>
{
    private readonly IContactRepository _repository;
 

    public UpdateContactCommandHandler(IContactRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultData<Contact>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var resultGet = await _repository.GetContactByIdAsync(request.Id);
        if (!resultGet.IsSuccess || resultGet.Data == null)
            return ResultData<Contact>.Failure("Contato não encontrado");

        var contact = resultGet.Data;

        contact.Name = request.Name;
        contact.Phone = request.Phone;
        contact.Email = request.Email;
        contact.DateOfBirth = request.DateOfBirth;

        if (request.Addresses != null && request.Addresses.Any())
        {
            contact.AddAddresses(request.Addresses);
        }

        return await _repository.UpdadeContactAsync(contact);
    }
}
