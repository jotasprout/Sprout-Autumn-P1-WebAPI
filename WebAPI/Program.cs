using Services;
using CustomExceptions;
using DataAccess;
using Models;
//using Microsoft.AspNetCore.Mvc;
//using WebAPI.Controllers;
//using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//builder.Services.AddControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();
