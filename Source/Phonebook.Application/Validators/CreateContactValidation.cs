using FluentValidation;
using Phonebook.Application.Input.Handlers.Commands;
using Phonebook.Domain.Dtos.Requests;

namespace Phonebook.Application.Validators
{
    public class CreateContactValidation : AbstractValidator<CreateContactCommand>
    {
        public CreateContactValidation()
        {
            RuleFor(x => x.AddContactRequest.Name).NotEmpty().WithMessage("Nome é obrigatório");

            RuleFor(x => x.AddContactRequest.Phone).NotEmpty().WithMessage("Telefone é obrigatório");

            RuleFor(x => x.AddContactRequest.Email)
                .NotEmpty().WithMessage("Email é obrigatório")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.AddContactRequest.Addresses)
                .NotNull()
                .WithMessage("Deve conter ao menos um endereço")
                .Must(addresses => addresses != null && addresses.Any(a => !string.IsNullOrWhiteSpace(a)))
                .WithMessage("Deve conter ao menos um endereço");
        }
    }
}
