using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Phonebook.CrossCutting.Models;
using Phonebook.Infrastructure.Data;

namespace Phonebook.CrossCutting.Extentions
{
    public static class MongoExtentions
    {
        public static IServiceCollection AddDataMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

            services.AddSingleton<IMongoDatabase>(provider =>
            {
                var mongoClient = new MongoClient(settings!.ConnectionString);
                var database = mongoClient.GetDatabase(settings.DatabaseName);

                return database;
            });


            services.AddSingleton<IMongoDbContext, MongoDbContext>();

            return services;
        }
    }
}
