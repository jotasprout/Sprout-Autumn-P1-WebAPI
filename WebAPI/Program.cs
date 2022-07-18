using Services;
using CustomExceptions;
using DataAccess;
using Models;
using Sensitive;
// using Microsoft.AspNetCore.Mvc;
// using WebAPI.Controllers;
// using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("AutumnERS")));
builder.Services.AddScoped<IuserDAO, UserRepository>();
builder.Services.AddTransient<UserServices>();
// builder.Services.AddTransient<UserController>();
builder.Services.AddScoped<IticketDAO, TicketRepository>();
builder.Services.AddTransient<TicketServices>();
builder.Services.AddTransient<AuthServices>();


// builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//
app.UseSwagger();
app.UseSwaggerUI();


// USERS

//app.MapGet("/users", (UserController controller) => controller.GetAllUsers());

app.MapGet("/users", () =>
{
    var scope = app.Services.CreateScope();
    UserServices getAll = scope.ServiceProvider.GetRequiredService<UserServices>();

    return getAll.GetAllUsers();
});


// Get User by USERNAME

// Get user by UserID


// LOGIN user

// CREATE user



// app.MapPost("/register", (User user) => 
// {
//     var scope = app.Services.CreateScope();
//     AuthServices service = scope.ServiceProvider.GetRequiredService<AuthServices>();

//     try
//     {
//         service.RegisterUser(user);
//         return Results.Created("/users", user);
//     }
//     catch (UsernameNotAvailable)
//     {
//         return Results.Conflict("this username already exists.");
//     }
// });


// Get USER by UserID



// TICKETS

// Get ALL tickets

app.MapGet("/tickets", () =>
{
    var scope = app.Services.CreateScope();
    TicketServices getAll = scope.ServiceProvider.GetRequiredService<TicketServices>();

    return getAll.GetAllTickets();
});


// Get ticket by STATUS

// UPDATE a ticket

// Get TICKETS by USER

// Get A ticket by ticketID


app.Run();
