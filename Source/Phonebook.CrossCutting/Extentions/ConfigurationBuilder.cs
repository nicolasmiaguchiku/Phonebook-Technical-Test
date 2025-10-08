using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Phonebook.CrossCutting.Models;

namespace Phonebook.CrossCutting.Extentions
{
    public static class ConfigurationBuilder
    {
        public static Settings GetApplicationSettings(this IConfiguration configuration, IHostEnvironment env)
        {
            var settings = configuration.GetSection("Settings").Get<Settings>();

            if (!env.IsDevelopment())
            {
                settings!.MongoDbSettings.ConnectionString = GetOrDefault("ConnectionString_Mongo", settings.MongoDbSettings.ConnectionString);
            }

            return settings!;
        }

        private static string GetOrDefault(string key, string fallback)
        {
            var value = Environment.GetEnvironmentVariable(key);
            return string.IsNullOrWhiteSpace(value) ? fallback ?? "" : value;
        }
    }
}

