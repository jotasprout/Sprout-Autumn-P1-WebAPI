using Models;
using System;
namespace DataAccess
{
    public interface IticketDAO
    {
        public List<Ticket> GetTickets(string those);
        public List<Ticket> GetAllTickets();
        public List<Ticket> GetTicketsByUserName(string userIWantTicketsFor);
        public List<Ticket> GetTicketsByUserID(string userIWantTicketsFor);
        public List<Ticket> GetTicketsByStatus();
        public List<Ticket> GrabTicketByTicketID(string ticketID);
        public List<Ticket> ResolveThisTicket(string ticketID, User CurrentUserIn);
        public List<Ticket> CreateTicket(User CurrentUser);
    }


    public interface IuserDAO
    {
        public List<User> GetUsers(string those);
        public List<User> GetAllUsers();
        public User GetUserByUserName(string userWanted);
        public User CreateUser(User newUser);
        public User GetUserByUserID(string userID);
    }
}

