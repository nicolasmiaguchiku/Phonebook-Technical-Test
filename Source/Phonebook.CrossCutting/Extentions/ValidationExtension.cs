using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Phonebook.Application.Validators;
using Phonebook.Domain.Dtos.Requests;


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

            services.AddScoped<IValidator<AddContactRequest>, CreateContactValidation>();

            services.AddScoped<IValidator<UpdadeContactRequest>, UpdateContactCommandValidator>();

        }
    }
}
