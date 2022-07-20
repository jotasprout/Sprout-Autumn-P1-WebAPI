using CustomExceptions;
using Models;
using Services;
using System;

namespace WebAPI.Controllers;

public class TicketController
{
    private readonly TicketServices _service;
    public TicketController(TicketServices service)
    {
        _service = service;
    }

    // UPDATE a ticket


    // Get ALL tickets
    public IResult GetAllTickets()    
    {
        List<Ticket> allTickets = _service.GetAllTickets();
        try
        {
            return Results.Accepted("/tickets", allTickets);
        }
        catch (ResourceNotFound)
        {
            return Results.NotFound("Indy sez you got no tickets.");
        }         
    }    


    // Get A ticket by ticketID
    public IResult GetTicketByTicketID(string ticketID)
    {
        List<Ticket> ticketByTicketID = _service.RequestTicketsByStatus(ticketID);
        try
        {
            return Results.Accepted("/tickets/ticketid/{ticketID}", ticketByTicketID);
        }
        catch(ResourceNotFound)
        {
            throw new ResourceNotFound("Indy sez there is no tickets with that ticketID.");
        }
    }


    // Get ticket by STATUS
    public IResult RequestTicketsByStatus(string ticketStatus)
    {
        List<Ticket> ticketsByStatus = _service.RequestTicketsByStatus(ticketStatus);
        try
        {
            return Results.Accepted("/tickets/author{username}", ticketsByStatus);
        }
        catch(ResourceNotFound)
        {
            throw new ResourceNotFound("Indy sez there are no tickets with that status.");
        }
    }

    // Get TICKETS by UserID
    public IResult GetTicketsByUserID(string author_fk)
    {
        List<Ticket> ticketsByUserID = _service.GetTicketsByUserID(author_fk);
        try
        {
            return Results.Accepted("/tickets/author{userID}", ticketsByUserID);
        }
        catch(ResourceNotFound)
        {
            throw new ResourceNotFound("Indy sez that employee's got no ticket.");
        }
    }

    // Get TICKETS by USERNAME
    public IResult GetTicketsByUserName(string author_fk)
    {
        List<Ticket> ticketsByUserName = _service.GetTicketsByUserName(author_fk);
        try
        {
            return Results.Accepted("/tickets/author{username}", ticketsByUserName);
        }
        catch(ResourceNotFound)
        {
            throw new ResourceNotFound("Indy sez that employee's got no ticket.");
        }
    }
}