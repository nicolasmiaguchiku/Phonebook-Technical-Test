using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Phonebook.Application.Validators;
using Phonebook.Application.Input.Handlers.Commands;


namespace Phonebook.CrossCutting.Extentions
{
    public static class ValidationExtension
    {
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<CreateContactCommand>, CreateContactValidation>();

            services.AddScoped<IValidator<UpdateContactCommand>, UpdateContactCommandValidator>();

        }
    }
}
