using Phonebook.CrossCutting.Extentions;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddControllers();

builder.Services.ConfigureMediatr()
                .AddDataMongo(builder.Configuration)
                .AddRepositorie()
                .AddValidator();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
