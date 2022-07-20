using Models;
using DataAccess;
using CustomExceptions;
using System;

namespace Services
{
    public class TicketServices
    {

        private readonly IticketDAO _ticketDAO;
        public TicketServices(IticketDAO ticketDAO)
        {
            _ticketDAO = ticketDAO;
        }
        

        public List<Ticket> GetTicketsByUserName(string userIWantTicketsFor)
        {
            try
            {
                return _ticketDAO.GetTicketsByUserName(userIWantTicketsFor);
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound("Indy sez that employee's got no ticket.");
            }
        }


        public List<Ticket> GetTicketByTicketID(string ticketID)
        {
            try
            {
                return _ticketDAO.GetTicketByTicketID(ticketID);
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }


        public List<Ticket> GetAllTickets()    
        {
            try
            {               
                return _ticketDAO.GetAllTickets();;      
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            } 
        }  


        public List<Ticket> CreateTicket(Ticket newTicket)
        {
            try
            {
                return _ticketDAO.CreateTicket(newTicket);
            }
            catch(InputInvalidException)
            {
                throw new InputInvalidException();
            }
        }


        public List<Ticket> GetTickets(string those)
        {
            try
            {
                return _ticketDAO.GetTickets(those);
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }
        
        
        public List<Ticket> GetTicketsByUserID(string userIWantTicketsFor)
        {
            return _ticketDAO.GetTicketsByUserID(userIWantTicketsFor);
        }


        public List<Ticket> GetTicketsByStatus()
        {
            try
            {
                return _ticketDAO.GetTicketsByStatus();
            }
            catch(ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }


        public List<Ticket> RequestTicketsByStatus(string ticketStatus)
        {
            try
            {
                return _ticketDAO.RequestTicketsByStatus(ticketStatus); 
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound();
            } 
        }


        public List<Ticket> ResolveThisTicket(string ticketID, User CurrentUserIn)
        {
            try
            {
                return _ticketDAO.ResolveThisTicket(ticketID, CurrentUserIn);
            }
            catch (ResourceNotFound)
            {
                throw new ResourceNotFound();
            }
        }

    }
}

