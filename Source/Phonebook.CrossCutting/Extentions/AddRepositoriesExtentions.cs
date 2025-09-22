using Microsoft.Extensions.DependencyInjection;
using Phonebook.Domain.Interfaces;
using Phonebook.Infrastructure.Repositories;

namespace Phonebook.CrossCutting.Extentions
{
    public static class AddRepositoriesExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IContactRepository, ContactRepository>();

            return service;
        }
    }
}
