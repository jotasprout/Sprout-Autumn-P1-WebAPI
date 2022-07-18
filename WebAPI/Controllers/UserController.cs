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
    public IResult UserByUserID(string userID)    
    {
        try
        {
            User userByUserID = _service.GetUserByUserID(userID);
            return Results.Accepted("/users/userid/{userID}", userByUserID);
        }
        catch (ResourceNotFound)
        {
            return Results.NotFound("We didn't find anything.");
        }         
    }   

    // Get User by USERNAME
    public IResult GetUserByUserName(string userWanted)    
    {
        try
        {
            User userByUserName = _service.GetUserByUserName(userWanted);
            return Results.Accepted("/users/{userName}", userByUserName);
        }
        catch (ResourceNotFound)
        {
            return Results.NotFound("We didn't find anything.");
        }         
    }   


}