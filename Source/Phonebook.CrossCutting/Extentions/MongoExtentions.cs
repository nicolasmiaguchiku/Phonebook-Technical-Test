using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Phonebook.CrossCutting.Models;

namespace Phonebook.CrossCutting.Extentions
{
    public static class MongoExtentions
    {
        public static IServiceCollection AddDataMongo(this IServiceCollection services, MongoDbSettings mongoSettings)
        {
            var clientSettings = MongoClientSettings.FromConnectionString(mongoSettings.ConnectionString);
            var mongoClient = new MongoClient(clientSettings);

            services.AddSingleton<IMongoClient>(_ => mongoClient);

            services.AddSingleton(sp =>
            {
                var mongoClient = sp.GetService<IMongoClient>()!;
                var db = mongoClient.GetDatabase(mongoSettings.DatabaseName);
                return db;
            });

            return services;
        }
    }
}
