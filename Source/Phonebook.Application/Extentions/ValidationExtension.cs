using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Phonebook.Application.Validators;
using Phonebook.Application.Commands;


namespace Phonebook.Application.Extensions
{
    public static class ValidationExtension
    {
        public static void AddValidator(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation(options =>
            {
                options.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<CreateContactCommand>,CreateContactValidation>();

        }
    }
}
