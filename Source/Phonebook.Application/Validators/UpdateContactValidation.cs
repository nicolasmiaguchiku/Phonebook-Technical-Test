
using FluentValidation;
using Phonebook.Application.Commands;

namespace Phonebook.Application.Validators
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefone é obrigatório");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email inválido");
        }
    }
}
