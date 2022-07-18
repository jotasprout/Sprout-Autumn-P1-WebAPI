﻿using Models;
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


        public List<Ticket> GrabTicketByTicketID(string ticketID)
        {
            return _ticketDAO.GrabTicketByTicketID(ticketID);
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


        public List<Ticket> CreateTicket(User CurrentUser)
        {
            return _ticketDAO.CreateTicket(CurrentUser);
        }


        public List<Ticket> GetTickets(string those)
        {
            return _ticketDAO.GetTickets(those);

        }
        
        
        public List<Ticket> GetTicketsByUserID(string userIWantTicketsFor)
        {
            return _ticketDAO.GetTicketsByUserID(userIWantTicketsFor);
        }


        public List<Ticket> GetTicketsByStatus()
        {
            return _ticketDAO.GetTicketsByStatus();

        }
        
        public List<Ticket> ResolveThisTicket(string ticketID, User CurrentUserIn)
        {
            return _ticketDAO.ResolveThisTicket(ticketID, CurrentUserIn);

        }


    }
}

