using Services;
using CustomExceptions;
using DataAccess;
using Models;
using Sensitive;
// using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
// using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("AutumnERS")));
builder.Services.AddScoped<IuserDAO, UserRepository>();
builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<UserController>();
builder.Services.AddTransient<TicketController>();
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

app.MapGet("/users", (UserController controller) => controller.GetAllUsers());
// app.MapGet("/users", () =>
// {
//     var scope = app.Services.CreateScope();
//     UserServices getAll = scope.ServiceProvider.GetRequiredService<UserServices>();

//     return getAll.GetAllUsers();
// });


app.MapGet("/users/{userName}", (UserController controller) => controller.GetUserByUserName(userName));
// Get User by USERNAME
// app.MapGet("/users/{userName}", (string userName) => 
// {
//     var scope = app.Services.CreateScope();
//     UserServices userByUserName = scope.ServiceProvider.GetRequiredService<UserServices>();
//     return userByUserName.GetUserByUserName(userName);
// });


app.MapGet("/users/userid/{userID}", (UserController controller) => controller.GetUserByUserID(userID));
// Get user by UserID
// app.MapGet("/users/userid/{userID}", (string userID) => 
// {
//     var scope = app.Services.CreateScope();
//     UserServices userByUserID = scope.ServiceProvider.GetRequiredService<UserServices>();
//     return userByUserID.GetUserByUserID(userID);
// });

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



// TICKETS
// UPDATE a ticket

app.MapGet("/tickets", (UserController controller) => controller.GetAllTickets());
// Get ALL tickets
// app.MapGet("/tickets", () =>
// {
//     var scope = app.Services.CreateScope();
//     TicketServices getAll = scope.ServiceProvider.GetRequiredService<TicketServices>();

//     return getAll.GetAllTickets();
// });


app.MapGet("/tickets/author/{userName}", (UserController controller) => controller.GetTicketsByUserName(userName));
// Get TICKETS by USERNAME
// app.MapGet("/tickets/author/{userName}", (string userName) => 
// {
//     var scope = app.Services.CreateScope();
//     TicketServices ticketsByUserName = scope.ServiceProvider.GetRequiredService<TicketServices>();
//     return ticketsByUserName.GetTicketsByUserName(userName);
// });

app.MapGet("/users/userid/{userID}", (UserController controller) => controller.GetUserByUserID(userID));
// Get A ticket by UserID
// app.MapGet("/tickets/userid/{userID}", (string userID) => 
// {
//     var scope = app.Services.CreateScope();
//     TicketServices ticketsByUserID = scope.ServiceProvider.GetRequiredService<TicketServices>();
//     return ticketsByUserID.GetTicketsByUserID(userID);
// });


app.MapGet("/tickets/ticketid/{ticketID}", (UserController controller) => controller.GetTicketByTicketID(ticketID));
// Get A ticket by ticketID
// app.MapGet("/tickets/ticketid/{ticketID}", (string ticketID) => 
// {
//     var scope = app.Services.CreateScope();
//     TicketServices ticketByTicketID = scope.ServiceProvider.GetRequiredService<TicketServices>();
//     return ticketByTicketID.GetTicketByTicketID(ticketID);
// });


app.MapGet("/tickets/status/{ticketstatus}", (UserController controller) => controller.RequestTicketsByStatus(ticketstatus));
// Get ticket by STATUS
// app.MapGet("/tickets/status/{ticketstatus}", (string ticketstatus) => 
// {
//     var scope = app.Services.CreateScope();
//     TicketServices ticketsByStatus = scope.ServiceProvider.GetRequiredService<TicketServices>();
//     return ticketsByStatus.RequestTicketsByStatus(ticketstatus);
// });

// app.Run();
