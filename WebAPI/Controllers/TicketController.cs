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

    //public List<Ticket> GetAllTickets()
    public IResult GetAllTickets()    
    {
        List<Ticket> allTickets = _service.GetAllTickets();
        try
        {
            return Results.Accepted("/tickets", allTickets);
        }
        catch (ResourceNotFound)
        {
            return Results.NotFound("we didn't find anything.");
        }         
        //return _service.GetAllTickets();
        // List<Ticket> allTickets = _service.GetAllTickets();
        // return allTickets;
    }    
}