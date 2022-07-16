using System;
using Services;
using Models;
//using DataAccess;
using CustomExceptions;

namespace UI
{
    public class EntryMenu
    {
        public void Begin()
        {
            do
            {
                Console.WriteLine("Welcome to AutumnERS, where expenses are as beautiful as Autumn leaves.");
                Console.WriteLine("What do you need to do?");
                Console.WriteLine("[1] Login");
                Console.WriteLine("[2] Register");
                Console.WriteLine("[3] Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": // Login
                        DisplayLoginUI();
                        break;
                    case "2": // register
                        DisplayRegisterUI();
                        break;
                    case "3": // Exit
                        Console.WriteLine("Goodbye.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("What kind of nonsense was that?");
                        break;
                }
            } while (true);
        }




        public void DisplayLoginUI()
        {
            Console.WriteLine("userName: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Password, too: ");
            string password = Console.ReadLine();

            User userKnocking;
            try
            {
                userKnocking = new AuthServices().LoginUser(userName, password);
                if (userKnocking.password == password && userKnocking.userName == userName)
                {
                    if (userKnocking.userRole == userRole.Manager)
                    {
                        ManagerMainMenu MgrMenu = new ManagerMainMenu();
                        MgrMenu.DisplayManagerMainMenu(userKnocking);
                    }
                    else 
                    {
                        EmployeeMenu EmpMenu = new EmployeeMenu();
                        EmpMenu.DisplayEmployeeMenu(userKnocking);
                    }
                }
                else
                {
                    Console.WriteLine("Access Denied");
                    Environment.Exit(0);
                }
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound("We don't seem to have anyone by that name.");
                Environment.Exit(0);
            }
            catch (InvalidCredentials)
            {
                throw new InvalidCredentials("those creds don't work.");
                Environment.Exit(0);
            }
            //Environment.Exit(0);
        }



        public void DisplayRegisterUI()
        {
            Console.WriteLine("Choose a userName");
            string maybeUserName = Console.ReadLine();
            Console.WriteLine("You typed " + maybeUserName + ".");
            Console.WriteLine("Type a password.");
            string maybePassword = Console.ReadLine();
            Console.WriteLine("Your role: ");
            Console.WriteLine("[1] Employee");
            Console.WriteLine("[2] Manager");
            string maybeRoleSelector = Console.ReadLine();
            userRole maybeRole = new userRole();
            switch (maybeRoleSelector)
            {
                case "1": // Employee
                    maybeRole = userRole.Employee; 
                    break;
                case "2": // Manager
                    maybeRole = userRole.Manager;
                    break;
                default:
                    Console.WriteLine("Thank you.");
                    break;
            }
            Console.WriteLine(" Attempting to register userName: " + maybeUserName + ", password: " + maybePassword + ", Role: " + maybeRole + ".");
            User maybeUser = new AuthServices().RegisterUser(maybeUserName, maybePassword, maybeRole);
            //Environment.Exit(0);
            DisplayLoginUI();
        }
    }
}