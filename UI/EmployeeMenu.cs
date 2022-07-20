using System;
using Services;
using Models;
using DataAccess;
using CustomExceptions;

namespace UI
{
    public class EmployeeMenu
    {
        
        private static TicketServices _tix;
        public EmployeeMenu(TicketServices tix)
        {
            _tix = tix;
        }
        public EmployeeMenu()
        {
            _tix = new TicketServices(new TicketRepository());
        }        

        public void DisplayEmployeeMenu(User CurrentUserIn)
        {
            Console.WriteLine("Choose a task:");
            Console.WriteLine("[1] Create a New Ticket");
            Console.WriteLine("[2] View My Tickets");
            string maybeTask = Console.ReadLine();
            switch (maybeTask)
            {
                case "1": // Create
                    // CurrentUser info
                    int myIDint = CurrentUser.userID;
                    string myIDstring = myIDint.ToString();
                    // Ticket info
                    Console.WriteLine("What is it?");
                    string ticketDescription = Console.ReadLine();
                    Console.WriteLine("How much?");
                    string ticketCost = Console.ReadLine();
                    List<Ticket> myNewTicket = new List<Ticket>(myIDstring, ticketDescription, ticketCost);
                    _tix.CreateTicket(myNewTicket);                    
                    break;
                case "2": // View
                    Console.WriteLine("Tickets submitted by .");
                    int myIDint = CurrentUserIn.userID;
                    string myIDstring = myIDint.ToString();
                    _tix.GetTicketsByUserID(myIDstring);
                    break;
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            //Environment.Exit(0);
        }   
    }
}