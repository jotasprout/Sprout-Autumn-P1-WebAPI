using System;
using Services;
using Models;
using DataAccess;
using CustomExceptions;

namespace UI
{
    public class ManagerTicketMenu
    {
        private static TicketServices _tix;
        public ManagerTicketMenu(TicketServices tix)
        {
            _tix = tix;
        }
        public ManagerTicketMenu()
        {
            _tix = new TicketServices(new TicketRepository());
        }        

        public void DisplayManagerTicketMenu(User CurrentUserIn)
        {
            //User userKnocking = CurrentUserIn;
            Console.WriteLine("Choose a task:");
            Console.WriteLine("[1] Create a New Ticket");
            Console.WriteLine("[2] My Tickets");
            Console.WriteLine("[3] View Ticket by TicketID");  
            Console.WriteLine("[4] View Tickets by UserName");
            Console.WriteLine("[5] View Tickets by Status");
            Console.WriteLine("[6] View Tickets by UserID");
            Console.WriteLine("[7] View Entire Ticket List"); 
            Console.WriteLine("[8] Approve or Deny a Ticket");                                   
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
                    

                    _tix.CreateTicket(myIDstring, ticketDescription, ticketCost); 
                    break;
                case "2": // All of MY tickets
                    Console.WriteLine("Here are all your tickets:");
                    int myIDint = CurrentUserIn.userID;
                    string myIDstring = myIDint.ToString();
                    _tix.GetTicketsByUserID(myIDstring);
                    break;                  
                case "3": // View Ticket by TicketID
                    Console.WriteLine("Enter ticketID.");
                    string ticketIDString = Console.ReadLine();
                    _tix.GrabTicketByTicketID(ticketIDString);                    
                    break;
                case "4": // View Tickets by UserName
                    Console.WriteLine("Which user do you want?");
                    string userIWantTicketsFrom = Console.ReadLine();
                    _tix.GetTicketsByUserName(userIWantTicketsFrom);
                    break;   
                case "5": // View Tickets by Status
                    _tix.GetTicketsByStatus();
                    //GetTicketsByStatus();
                    break;          
                case "6": // View Tickets by UserID
                    Console.WriteLine("Enter userID.");
                    string userIDforTicketsFrom = Console.ReadLine();
                    _tix.GetTicketsByUserID(userIDforTicketsFrom);
                    break;                     
                case "7": // View Entire Ticket List
                    Console.WriteLine("Here is a list of all Tickets:");
                    _tix.GetAllTickets();
                    break;     
                case "8": // Resolve a ticket               
                    Console.WriteLine("Enter ticketID.");
                    string ticketIDtoResolve = Console.ReadLine();
                    _tix.ResolveThisTicket(ticketIDtoResolve, CurrentUserIn);                  
                    break;                                                                        
                default:
                    Console.WriteLine("You're a dummy.");
                    break;
            }
            //Environment.Exit(0);
        }

    }
}