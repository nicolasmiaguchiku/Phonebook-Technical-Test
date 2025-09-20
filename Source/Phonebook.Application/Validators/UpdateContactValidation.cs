
using FluentValidation;
using Phonebook.Application.Handlers.Commands;

namespace Phonebook.Application.Validators
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefone é obrigatório");

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Email é obrigatório")
               .EmailAddress().WithMessage("Email inválido");


            RuleFor(x => x.Addresses)
                .NotNull()
                .WithMessage("Deve conter ao menos um endereço")
                .Must(addresses => addresses != null && addresses.Any(a => !string.IsNullOrWhiteSpace(a)))
                .WithMessage("Deve conter ao menos um endereço");
        }
    }
}
