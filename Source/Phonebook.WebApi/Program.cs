using Phonebook.Application.Extensions;
using Phonebook.Domain.Interfaces;
using Phonebook.Infrastructure.Extensions;

using Phonebook.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataMongo(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddValidator();


builder.Services.AddScoped<IContactRepository, ContactRepository>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();