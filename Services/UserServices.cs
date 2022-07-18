using Models;
using CustomExceptions;
using DataAccess;
using System;

namespace Services
{
    public class UserServices
    {

        private readonly IuserDAO _repo;
        public UserServices(IuserDAO repo)
        {
            _repo = repo;
        }
        public UserServices()
        {
            _repo = new UserRepository();
        }

        public List<User> GetUsers(string those)
        {
            return _repo.GetUsers(those);
        }

        public List<User> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }

        public User GetUserByUserName(string userWanted)
        {
            return _repo.GetUserByUserName(userWanted);
        }             

        public User CreateUser(User newUser)
        {
            return _repo.CreateUser(newUser);
        }

        public User GetUserByUserID(string userID)
        {
            return _repo.GetUserByUserID(userID);
        }
 
    }
}

