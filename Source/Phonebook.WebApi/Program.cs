using Phonebook.CrossCutting.Extentions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

builder.Configuration
    .AddJsonFile("appsettings.json", false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{enviroment}.json", true, reloadOnChange: true)
    .AddEnvironmentVariables();

var applicationSettings = builder.Configuration.GetApplicationSettings(builder.Environment);

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureMediatr()
                .AddDataMongo(applicationSettings.MongoDbSettings)
                .AddRepositories()
                .AddValidators();

builder.Services.AddOpenApi("v1");

builder.Services.AddControllers();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference(options => options.Servers = []);

app.UseHttpsRedirection();
app.MapControllers();

await app.RunAsync();
