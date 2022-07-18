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
        //return _service.GetAllTickets();
        // List<Ticket> allTickets = _service.GetAllTickets();
        // return allTickets;
    }    




// Get ticket by STATUS

// UPDATE a ticket

// Get TICKETS by USER

// Get A ticket by ticketID

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