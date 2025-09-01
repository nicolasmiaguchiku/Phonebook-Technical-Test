using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Shared.Results;
using Phonebook.Application.Commands;
using FluentValidation;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ResultData<Contact>>
{
    private readonly IContactRepository _repository;
    private readonly IValidator<UpdateContactCommand> _validator;

    public UpdateContactCommandHandler(IContactRepository repository, IValidator<UpdateContactCommand> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<ResultData<Contact>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            return ResultData<Contact>.Failure(errors);
        }

        ResultData<Contact> contactEntity = await _repository.GetContactByIdAsync(request.Id);

        if (!contactEntity.IsSuccess || contactEntity.Data == null)
            return ResultData<Contact>.Failure("Contato não encontrado");

        var contact = contactEntity.Data;

        contact.Name = request.Name;
        contact.Phone = request.Phone;
        contact.Email = request.Email;
        contact.DateOfBirth = request.DateOfBirth;
        contact.AddAddresses(request.Addresses);


        return await _repository.UpdadeContactAsync(contact);
    }


}
