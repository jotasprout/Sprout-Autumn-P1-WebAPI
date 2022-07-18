using CustomExceptions;
using Models;
using Services;
using System;

namespace WebAPI.Controllers;

public class UserController
{
    private readonly UserServices _service;
    public UserController(UserServices service)
    {
        _service = service;
    }

    // Get ALL users

    public IResult GetAllUsers()    
    {
        try
        {
            List<User> allUsers = _service.GetAllUsers();
            return Results.Accepted("/users", allUsers);
        }
        catch (ResourceNotFound)
        {
            return Results.NotFound("we didn't find anything.");
        }         

    }    

// Get USER by UserID

// Get User by USERNAME



}