﻿using Models;
using Sensitive;
using CustomExceptions;
using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class UserRepository : IuserDAO
    {

        public string thoseAll = "select * from users;";

        private readonly ConnectionFactory _connectionFactory;

        public UserRepository()
        {
            _connectionFactory = ConnectionFactory.GetInstance(File.ReadAllText("../Sensitive/connectionString.txt"));
        }

        public UserRepository(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<User> GetUsers(string those)
        {

            List<User> users = new List<User>();
            User tempUserHoldingRole = new User();

            SqlConnection makeConnection = _connectionFactory.GetConnection();
            SqlCommand getEveryUser = new SqlCommand(those, makeConnection);

            try
            {
                makeConnection.Open();
                SqlDataReader reader = getEveryUser.ExecuteReader();

                while (reader.Read())
                {
                    //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}", reader[0], reader[1], reader[2], reader[3]);
                    int RoleFromDB = tempUserHoldingRole.userRoleToInt((string)reader[3]); 
                    users.Add(new User((int)reader[0], (string)reader[1], (string)reader[2], (userRole)RoleFromDB));
                }
                reader.Close();
                makeConnection.Close();
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
            return users;
        }

        public List<User> GetAllUsers()
        {
            try
            {            
            return GetUsers(thoseAll);
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound();
            }         
        }

        public User GetUserByUserName(string userWanted)
        {
            User thisUser = new User();
            User tempUserHoldingRole = new User();

            string getThisUser = "select * from users where userName ='" + userWanted + "';";

            SqlConnection makeConnection = _connectionFactory.GetConnection();
            SqlCommand goGetThisUser = new SqlCommand(getThisUser, makeConnection);

            try
            {
                makeConnection.Open();
                SqlDataReader reader = goGetThisUser.ExecuteReader();
                while (reader.Read())
                {
                    int RoleFromDB = tempUserHoldingRole.userRoleToInt((string)reader[3]); 
                    thisUser = new User((int)reader[0], (string)reader[1], (string)reader[2], (userRole)RoleFromDB);
                }
                reader.Close();
                makeConnection.Close();
            }
            catch (ResourceNotFound e)
            {
                throw new ResourceNotFound();
            }
            return thisUser;
        }

        public User CreateUser(User newUser)
        {
            User thisUser = newUser;

            string putUserInDB = "insert into users (userName, password, userRole) values (@userName, @password, @userRole);";

            SqlConnection makeConnection = _connectionFactory.GetConnection();
            
            SqlCommand saveUser = new SqlCommand(putUserInDB, makeConnection);
            
            saveUser.Parameters.AddWithValue("@userName", thisUser.userName);
            saveUser.Parameters.AddWithValue("@password", thisUser.password);
            saveUser.Parameters.AddWithValue("@userRole", thisUser.userRoleToString(thisUser.userRole));         

            try{
                makeConnection.Open();
                int itWorked = saveUser.ExecuteNonQuery();
                makeConnection.Close();
                if (itWorked != 0)
                {
                    Console.WriteLine("Welcome to our club, " + thisUser.userName + "!");
                    User userWhy = GetUserByUserName(thisUser.userName);
                    return userWhy;
                }
                else
                {
                    Console.WriteLine("Sorry, something didn't work.");
                    throw new UsernameNotAvailable();
                }
            }
            catch (UsernameNotAvailable)
            {
                throw new UsernameNotAvailable();
            }            
        }


        public User GetUserByUserID(string userID)
        {
            User thisUser = new User();
            User tempUserHoldingRole = new User();

            string getThisUser = "select * from users where userID ='" + userID + "';";

            SqlConnection makeConnection = _connectionFactory.GetConnection();
            SqlCommand goGetThisUser = new SqlCommand(getThisUser, makeConnection);

            try
            {
                makeConnection.Open();
                SqlDataReader reader = goGetThisUser.ExecuteReader();
                while (reader.Read())
                {
                    int RoleFromDB = tempUserHoldingRole.userRoleToInt((string)reader[3]); 
                    thisUser = new User((int)reader[0], (string)reader[1], (string)reader[2], (userRole)RoleFromDB);
                }
                reader.Close();
                makeConnection.Close();
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
            return thisUser;
        }

    }
}

