using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Phonebook.Infrastructure.Data;
using Phonebook.Shared.Configuration;

namespace Phonebook.Infrastructure.Extensions
{
    public static class MongoDbExtentions
    {
        public static void AddDataMongo(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

            services.AddSingleton<IMongoDatabase>(provider =>
            {
                var mongoClient = new MongoClient(settings!.ConnectionString);
                var database = mongoClient.GetDatabase(settings.DatabaseName);

                return database;
            });

            services.AddSingleton<IMongoDbContext, MongoDbContext>();
        }
    }
}
