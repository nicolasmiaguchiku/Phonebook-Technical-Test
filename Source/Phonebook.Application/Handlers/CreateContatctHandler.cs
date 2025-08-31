using Phonebook.Application.Commands;
using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Shared.Results;
using FluentValidation;


namespace Phonebook.Application.Handlers
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, ResultData<Contact>>
    {
        private readonly IContactRepository _repositoryContact;
        private readonly IValidator<CreateContactCommand> _validator;

        public CreateContactHandler(IContactRepository repository, IValidator<CreateContactCommand> validator)
        {
            _repositoryContact = repository;
            _validator = validator;
        }

        public async Task<ResultData<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return ResultData<Contact>.Failure(errors);
            }
            else
            {
                var contato = new Contact
                {
                    Name = request.Name,
                    Phone = request.Phone,
                    Email = request.Email,
                    DateOfBirth = request.DateOfBirth
                };

                contato.AddAddresses(request.Addresses);

                return await _repositoryContact.CreateContactAsync(contato);
            }

           
        }
    }
}
