using Microsoft.Extensions.DependencyInjection;
using Phonebook.Application.Handlers.Commands;
using Phonebook.Application.Handlers.Queries;

namespace Phonebook.CrossCutting.Extentions
{
    public static class MediatorExtentions
    {
        public static IServiceCollection ConfigureMediatr(this IServiceCollection services)
        {
            var applicationAssemblyQuery = typeof(GetAllContactsQuery).Assembly;

            var applicationAssemblyCommand = typeof(CreateContactCommand).Assembly;

            services.AddMediatR(mediatir =>
            {
                mediatir.RegisterServicesFromAssembly(applicationAssemblyQuery);
            });

            services.AddMediatR(mediatir =>
            {
                mediatir.RegisterServicesFromAssembly(applicationAssemblyCommand);
            });


            return services;
        }
    }
}
