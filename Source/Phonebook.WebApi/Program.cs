using Phonebook.CrossCutting.Extentions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureMediatr()
                .AddDataMongo(builder.Configuration)
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
