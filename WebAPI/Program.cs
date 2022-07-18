using Services;
using CustomExceptions;
using DataAccess;
using Models;
//using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
//using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("AutumnERS")));
builder.Services.AddScoped<IuserDAO, UserRepository>();
builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<UserController>();
builder.Services.AddScoped<IticketDAO, TicketRepository>();
builder.Services.AddTransient<TicketServices>();
builder.Services.AddTransient<AuthServices>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//builder.Services.AddControllers();
app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/users", (UserController controller) => controller.GetAllUsers());

app.MapGet("/users", () => 
{
    var scope = app.Services.CreateScope();
    UserServices service = scope.ServiceProvider.GetRequiredService<UserServices>();
    return service.GetAllUsers();
});

// app.MapPost("/register", () => 
// {
//     var scope = app.Services.CreateScope();
//     AuthServices service = scope.ServiceProvider.GetRequiredService<AuthServices>();

//     try
//     {
//         service.Register();
//     }
//     catch (DuplicateRecordException)
//     {
//         // do something
//     }
// });

app.Run();
