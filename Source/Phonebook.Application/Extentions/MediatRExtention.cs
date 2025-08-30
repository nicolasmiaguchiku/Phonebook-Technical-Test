using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Phonebook.Application.Extensions
{
    public static class MediatRExtention
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
