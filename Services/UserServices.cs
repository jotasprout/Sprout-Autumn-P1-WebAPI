using Models;
using CustomExceptions;
using DataAccess;
using System;

namespace Services
{
    public class UserServices
    {

        private readonly IuserDAO _userDAO;
        public UserServices(IuserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        public UserServices()
        {
            _userDAO = new UserRepository();
        }

        public List<User> GetUsers(string those)
        {
            return _userDAO.GetUsers(those);
        }

        // public List<User> GetAllUsers()
        // {           
        //     return _userDAO.GetAllUsers();
        // }

        public List<User> GetAllUsers()    
        {
            //List<User> allUsers = _userDAO.GetAllUsers();
            try
            {               
            return _userDAO.GetAllUsers();;      
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            } 
        }           

        public User GetUserByUserName(string userWanted)
        {
            return _userDAO.GetUserByUserName(userWanted);
        }             

        public User CreateUser(User newUser)
        {
            return _userDAO.CreateUser(newUser);
        }

        public User GetUserByUserID(string userID)
        {
            return _userDAO.GetUserByUserID(userID);
        }
 
    }
}

