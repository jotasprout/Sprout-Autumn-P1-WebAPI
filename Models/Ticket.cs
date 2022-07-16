namespace Models;

// using customExceptions;

public class Ticket
{
    public int ticketID { get; set; }
    public int author_fk { get; set; }
    public int resolver_fk { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public decimal amount { get; set; }




    // for retrieving objects from database
    public Ticket(
        int ticketID,
        int author_fk,
        int resolver_fk,
        string description,
        string status,
        decimal amount)
    {
        this.ticketID = ticketID;
        this.author_fk = author_fk;
        this.resolver_fk = resolver_fk;
        this.description = description;
        this.status = status;
        this.amount = amount;
    }

    // for putting objects into database
    public Ticket(
        int author_fk,
        string description,
        string status,
        decimal amount)
    {
        this.author_fk = author_fk;
        this.description = description;
        this.status = status;
        this.amount = amount;
    }



    public Ticket(
        string description,
        decimal amount
        )
    {
        this.description = description;
        this.amount = amount;
    }
    /*
        public enum status {
        Pending, 
        Approved,
        Denied
        }
    */
    public override string ToString()
    {
        return "ID: " + this.ticketID +
        ", Author: " + this.author_fk +
        ", Manager: " + this.resolver_fk +
        ", Status: " + this.status +
        ", Description: " + this.description +
        ", Amount: " + this.amount;
    }

}