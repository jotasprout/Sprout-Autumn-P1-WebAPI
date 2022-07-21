using Services;
using CustomExceptions;
using DataAccess;
using Models;
using Sensitive;
// using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
//using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ConnectionFactory>(ctx => ConnectionFactory.GetInstance(builder.Configuration.GetConnectionString("AutumnERS")));
builder.Services.AddScoped<IuserDAO, UserRepository>();
builder.Services.AddTransient<UserServices>();
builder.Services.AddTransient<UserController>();
builder.Services.AddTransient<TicketController>();
builder.Services.AddScoped<IticketDAO, TicketRepository>();
builder.Services.AddTransient<TicketServices>();
builder.Services.AddTransient<AuthServices>();
builder.Services.AddTransient<AuthController>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//
app.UseSwagger();
app.UseSwaggerUI();


// USERS
// Get ALL users
app.MapGet("/users", (UserController controller) => controller.GetAllUsers());
// Get User by USERNAME
app.MapGet("/users/username/{userName}", (string userName, UserController controller) => controller.GetUserByUserName(userName));
// Get user by UserID
app.MapGet("/users/userid/{userID}", (string userID, UserController controller) => controller.GetUserByUserID(userID));

// LOGIN user
app.MapPost("/login", (string userName, string password, AuthController controller) => controller.LoginUser(userName, password));

// CREATE user
app.MapPost("/register", (User newUser, AuthController controller) => controller.RegisterUser(newUser));


// TICKETS
// UPDATE a ticket
app.MapPost("/tickets/update", (Ticket updatedTicket, TicketController controller) => controller.ResolveThisTicket(updatedTicket));

// CREATE a ticket
//app.MapPost("/tickets/create", (string authorID, string Description, string cost, TicketController controller) => controller.CreateTicket(authorID, Description, cost));
app.MapPost("/tickets/create", (Ticket newTicket, TicketController controller) => controller.CreateTicket(newTicket));

// Get ALL tickets
app.MapGet("/tickets", (TicketController controller) => controller.GetAllTickets());

// app.MapGet("/tickets", () =>
// {
//     var scope = app.Services.CreateScope();
//     TicketServices getAll = scope.ServiceProvider.GetRequiredService<TicketServices>();

//     return getAll.GetAllTickets();
// });


app.MapGet("/tickets/username/{userName}", (string userName, TicketController controller) => controller.GetTicketsByUserName(userName));
// Get TICKETS by USERNAME
// app.MapGet("/tickets/author/{userName}", (string userName) => 
// {
//     var scope = app.Services.CreateScope();
//     TicketServices ticketsByUserName = scope.ServiceProvider.GetRequiredService<TicketServices>();
//     return ticketsByUserName.GetTicketsByUserName(userName);
// });

app.MapGet("/tickets/userid/{userID}", (string userID, TicketController controller) => controller.GetTicketsByUserID(userID));
// Get A ticket by UserID
// app.MapGet("/tickets/userid/{userID}", (string userID) => 
// {
//     var scope = app.Services.CreateScope();
//     TicketServices ticketsByUserID = scope.ServiceProvider.GetRequiredService<TicketServices>();
//     return ticketsByUserID.GetTicketsByUserID(userID);
// });


app.MapGet("/tickets/ticketid/{ticketID}", (string ticketID, TicketController controller) => controller.GetTicketByTicketID(ticketID));
// Get A ticket by ticketID
// app.MapGet("/tickets/ticketid/{ticketID}", (string ticketID) => 
// {
//     var scope = app.Services.CreateScope();
//     TicketServices ticketByTicketID = scope.ServiceProvider.GetRequiredService<TicketServices>();
//     return ticketByTicketID.GetTicketByTicketID(ticketID);
// });


app.MapGet("/tickets/status/{ticketstatus}", (string ticketstatus, TicketController controller) => controller.RequestTicketsByStatus(ticketstatus));
// Get ticket by STATUS
// app.MapGet("/tickets/status/{ticketstatus}", (string ticketstatus) => 
// {
//     var scope = app.Services.CreateScope();
//     TicketServices ticketsByStatus = scope.ServiceProvider.GetRequiredService<TicketServices>();
//     return ticketsByStatus.RequestTicketsByStatus(ticketstatus);
// });

app.Run();
