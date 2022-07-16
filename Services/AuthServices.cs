using Models;
using DataAccess;
using Sensitive;
using CustomExceptions;
using System;
using System.Data.SqlClient;

namespace Services;

public class AuthServices
{
    private readonly UserRepository _user;

    public User CurrentUser = new User();    

    public AuthServices()
    {
        _user = new UserRepository();
    }

    // public AuthServices(ConnectionFactory connectionFactory)
    // {
    //     something goes here;
    // }

    public User LoginUser(string userName, string password)
    {
        // create temp user object to store data retrieved from DataAccess layer
        User wantsInside = new User(userName,password);
        try
        {
            // retrieve user from database using DataAccess method
            User lookInside = _user.GetUserByUserName(userName);
            // if password for parameter user matches password from database user
            if (wantsInside.userName != lookInside.userName)
            {
                Console.WriteLine("That was messed up.");
                throw new ResourceNotFound();
            }
            if (wantsInside.password == lookInside.password)
            // return user to UI layer
            {
                CurrentUser = lookInside;
                Console.WriteLine("You are logged in as userName: " + CurrentUser.userName + ", with userID: " + CurrentUser.userID + " and password: " + CurrentUser.password + " is a " + CurrentUser.userRole);
                //return CurrentUser;
                return lookInside;
            }
            else
            {
                Console.WriteLine("Your credentials are no good.");
                // throw custom exception if passwords don't match
                throw new InvalidCredentials();
            }
        }
        // catch any exception thrown from DataAccess
        catch (InvalidCredentials e)
        {
            // if exception caught, throw to the UI layer 
            Console.WriteLine(e.Message);
            return new User();
        }
        catch (ResourceNotFound e)
        {
            // if exception caught, throw to the UI layer 
            Console.WriteLine(e.Message);
            return new User();
        }        
    }


    public User RegisterUser(string userName, string password, userRole userRole)
    {
        User thisUser = new User(userName, password, userRole);

        try
        {
            User userWannabe = _user.GetUserByUserName(userName);
            if (userWannabe.userName == thisUser.userName)
            {
                throw new UsernameNotAvailable();
            }
            else if (thisUser.userName == "")
            {
                throw new UsernameNotAvailable();
            }
            else 
            {
                User thatUser = _user.CreateUser(thisUser);
                return thatUser;
            }
        }
        catch(UsernameNotAvailable)
        {
            throw new UsernameNotAvailable();
        }
        catch(ResourceNotFound)
        {
            return _user.CreateUser(thisUser);
        }
    }
}

