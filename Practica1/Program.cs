using Application.Interface;
using Application.UseCase;
//using Infraestructure.Query;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Infraestructure.Query;
//using Infraestructure.Command;
using System;
using Infraestructure.Command;

//1° Problema: Cada vez que compilo, se añaden datos con IDs cada vez mas grandes, como si los que borre siguieran en la base de datos. 
//No se si esta bien del todo el resultado que me da la funcion, porque cada vez que se ejecute, se añadiran los objetos creados desde  
//el codigo nuevamente, pero con IDs mas grandes


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Propio
var connectionString = builder.Configuration["ConnectionString"];


//Esto es la coneccion con la base de datos
//////builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApiContext>(option => option.UseSqlServer(connectionString));


//Injeccion de dependecias
//////builder.Services.AddScoped<IStudentServices, StudentServices>();
//////builder.Services.AddScoped<IStudentQuery, StudentQuery>();
//////builder.Services.AddScoped<IStudentCommand, StudentCommand>();
//////builder.Services.AddTransient<UserInterface, ServicesGetAll>();
builder.Services.AddScoped<ICampaignTypeServices, CampaignTypeServices>();
builder.Services.AddScoped<ICampaignTypeQuery, CampaignTypeQuery>();
builder.Services.AddScoped<ICampaignTypeCommand, CampaignTypeCommand>();

builder.Services.AddScoped<IInteractionTypeServices, InteractionTypeServices>();
builder.Services.AddScoped<IInteractionTypeQuery, InteractionTypeQuery>();
builder.Services.AddScoped<IInteractionTypeCommand, InteractionTypeCommand>();
//Esto es agregar dependecia. Cuando quieras injectar una instancia de UserInterface, te va a pasar una instancia de ServicesGetAll




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
