using FluentValidation;
using Phonebook.Application.Commands;

namespace Phonebook.Application.Validators
{
    public class CreateContactValidation : AbstractValidator<CreateContactCommand>
    {
        public CreateContactValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefone é obrigatório");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email inválido");
            RuleFor(x => x.Addresses).NotNull().NotEmpty().WithMessage("Deve conter ao menos um endereço");
        }
    }
}
