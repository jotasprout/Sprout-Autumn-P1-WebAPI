using CustomExceptions;
using Models;
using Services;

namespace WebAPI.Controllers;

public class UserController
{
    private readonly UserServices _service;
    public UserController(UserServices service)
    {
        _service = service;
    }

    public List<User> GetAllUsers()
    {
        return _service.GetAllUsers();
        // List<User> allusers = _service.GetAllUsers();
        // return Results.Accepted("/users", allusers);
    }    
}