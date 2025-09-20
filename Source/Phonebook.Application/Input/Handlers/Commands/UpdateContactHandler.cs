using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;
using FluentValidation;
using Phonebook.Application.Input.Handlers.Commands;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, ResultData<Contact>>
{
    private readonly IContactRepository _repository;
    private readonly IValidator<UpdateContactCommand> _validator;

    public UpdateContactCommandHandler(IContactRepository Repository, IValidator<UpdateContactCommand> Validator)
    {
        _repository = Repository;
        _validator = Validator;
    }

    public async Task<ResultData<Contact>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        ResultData<Contact> result;
        ResultData<Contact> contactEntity = await _repository.GetContactByIdAsync(request.Id);

        if (!contactEntity.IsSuccess || contactEntity.Data == null)     
        {
            result = ResultData<Contact>.Failure("Contato não encontrado");
            return result;
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            result =  ResultData<Contact>.Failure(errors);
            return result;
        }
        else
        {
            var contact = contactEntity.Data;

            contact.Name = request.Name;
            contact.Phone = request.Phone;
            contact.Email = request.Email;
            contact.DateOfBirth = request.DateOfBirth;
            contact.AddAddresses(request.Addresses);

            result = await _repository.UpdadeContactAsync(contact);
            return result;
        }

    }


}
