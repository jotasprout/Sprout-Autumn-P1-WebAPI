using Models;
using DataAccess;
using CustomExceptions;
using System;

namespace Services
{
    public class TicketServices
    {

        private readonly IticketDAO _repo;
        public TicketServices(IticketDAO repo)
        {
            _repo = repo;
        }
        
        public List<Ticket> GetTicketsByUserName(string userIWantTicketsFor)
        {
            return _repo.GetTicketsByUserName(userIWantTicketsFor);
        }

        public List<Ticket> GrabTicketByTicketID(string ticketID)
        {
            return _repo.GrabTicketByTicketID(ticketID);
        }

        public List<Ticket> GetAllTickets()
        {
            return _repo.GetAllTickets();
        }

        public List<Ticket> CreateTicket(User CurrentUser)
        {
            return _repo.CreateTicket(CurrentUser);
        }


        public List<Ticket> GetTickets(string those)
        {
            return _repo.GetTickets(those);

        }
        
        
        public List<Ticket> GetTicketsByUserID(string userIWantTicketsFor)
        {
            return _repo.GetTicketsByUserID(userIWantTicketsFor);
        }


        public List<Ticket> GetTicketsByStatus()
        {
            return _repo.GetTicketsByStatus();

        }
        
        public List<Ticket> ResolveThisTicket(string ticketID, User CurrentUserIn)
        {
            return _repo.ResolveThisTicket(ticketID, CurrentUserIn);

        }


    }
}

