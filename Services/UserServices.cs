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

        public List<User> GetAllUsers()    
        {
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
            try
            {
                return _userDAO.GetUserByUserName(userWanted);
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }             

        public User CreateUser(User newUser)
        {
            try
            {
                return _userDAO.CreateUser(newUser);
            }
            catch(InputInvalidException)
            {
                throw new InputInvalidException();
            }
        }

        public User GetUserByUserID(string userID)
        {
            try
            {
                return _userDAO.GetUserByUserID(userID);
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }
 
    }
}

