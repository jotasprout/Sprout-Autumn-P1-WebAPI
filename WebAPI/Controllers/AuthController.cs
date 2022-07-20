using Services;
using Models;
using CustomExceptions;

namespace WebAPI.Controllers
{
    public class AuthController
    {
        private readonly AuthServices _authServices;
        public AuthController (AuthServices services)
        {
            _authServices = services;
        }
        public AuthController ()
        {
            _authServices = new AuthServices();
        }
        // In an AUTH CONTROLLER CLASS
        // method for handling HTTP REQUESTS for LOGIN attempts
        // ADD a TRY call to the AuthService LOGIN method and return user info with a 200 STATUS
        // ADD a CATCH and CUSTOM EXCEPTION to the LOGIN method below and return a 401 STATUS    



        // In an AUTH CONTROLLER CLASS
        // method for handling HTTP REQUESTS for REGISTER attempts
        // ADD a TRY call to the AuthService CREATE USER method and return user info with a 201 STATUS
        // ADD a CATCH and CUSTOM EXCEPTION to the CREATE USER method below and return a 400 STATUS    

        public IResult RegisterUser(User user)
        {
            try
            {
                _authServices.RegisterUser(user);
                return Results.Created("/register", user);                
            }
            catch (UsernameNotAvailable)
            {
                return Results.Conflict("Sorry, that username isn't available. Keep trying, pal.");
            }
        }
    }



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
}
