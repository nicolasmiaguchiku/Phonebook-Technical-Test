using MediatR;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Interfaces;
using Phonebook.Domain.Results;
using FluentValidation;


namespace Phonebook.Application.Handlers.Commands
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, ResultData<Contact>>
    {
        private readonly IContactRepository _repositoryContact;
        private readonly IValidator<CreateContactCommand> _validator;

        public CreateContactHandler(IContactRepository Repository, IValidator<CreateContactCommand> Validator)
        {
            _repositoryContact = Repository;
            _validator = Validator;
        }

        public async Task<ResultData<Contact>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            ResultData<Contact> result;

            var validationResult = await _validator.ValidateAsync(request, cancellationToken)
                ;
            if (!validationResult.IsValid)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                result = ResultData<Contact>.Failure(errors);
                return result;
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

                result = await _repositoryContact.CreateContactAsync(contato);
                return result;
            }

           
        }
    }
}
