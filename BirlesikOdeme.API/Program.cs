using BirlesikOdeme.Core.Extensions;
using BirlesikOdeme.Core.Filters;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation( 
    x=>x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddMvc(x => x.Filters.Add<ErrorFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrasturctureRegistration(); //INJECTION
builder.Services.AddApplicationRegistration();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
