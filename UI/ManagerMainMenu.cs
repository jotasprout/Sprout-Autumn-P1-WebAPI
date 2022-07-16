using System;
using Services;
using Models;
//using DataAccess;
using CustomExceptions;

namespace UI
{
    public class ManagerMainMenu
    {
        public void DisplayManagerMainMenu(User CurrentUserIn)
        {
            User userKnocking = CurrentUserIn;
            Console.WriteLine("Manage:");
            Console.WriteLine("[1] Employees");
            Console.WriteLine("[2] Tickets");                     
            string maybeTask = Console.ReadLine();
            switch (maybeTask)
            {
                case "1": // Employees
                    ManagerUserMenu MgrUser = new ManagerUserMenu();
                    MgrUser.DisplayManagerUserMenu(userKnocking);
                    break;                 
                case "2": // Tickets
                    ManagerTicketMenu MgrTix = new ManagerTicketMenu();
                    MgrTix.DisplayManagerTicketMenu(userKnocking);
                    break;                  
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            //Environment.Exit(0);
        }
    }
}