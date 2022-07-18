using Models;
using Sensitive;
using CustomExceptions;
using System.Data.SqlClient;

namespace DataAccess;

public class TicketRepository : IticketDAO
{

    private readonly ConnectionFactory _connectionFactory;

    public TicketRepository()
    {
        _connectionFactory = ConnectionFactory.GetInstance(File.ReadAllText("../Sensitive/connectionString.txt"));
    }

    public TicketRepository(ConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }


    public string thoseAll = "select * from AutumnERS.tickets;";


    public List<Ticket> GetTickets(string those)
    {



        try
        {
            List<Ticket> tickets = new List<Ticket>();
            SqlConnection makeConnection = _connectionFactory.GetConnection();
            SqlCommand getEveryTicket = new SqlCommand(those, makeConnection);            
            makeConnection.Open();
            SqlDataReader reader = getEveryTicket.ExecuteReader();

            while (reader.Read())
            {
                //Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                tickets.Add(new Ticket((int)reader[0], (int)reader[1], (int)reader[2], (string)reader[3], (string)reader[4], (decimal)reader[5]));
                //return tickets;
            }
            reader.Close();
            makeConnection.Close();
            return tickets;
        }
        catch (ResourceNotFound)
        {
            throw new ResourceNotFound();
        }
        //
    }


    public List<Ticket> GetAllTickets()
    {
        //List<Ticket> allTickets = new List<Ticket>();
        try
        {        
            return GetTickets(thoseAll);;
        }
        catch (ResourceNotFound)
        {
            throw new ResourceNotFound();
        }        
        //return allTickets;
    }

    public List<Ticket> GetTicketsByUserName(string userIWantTicketsFor)
    {
        try
        {
            User userInQuestion = new UserRepository().GetUserByUserName(userIWantTicketsFor);
            int userID = userInQuestion.userID;
            string byUserQueryWithID = "select * from AutumnERS.tickets where author_fk = " + userID + ";";
            return GetTickets(byUserQueryWithID);
        }
        catch(ResourceNotFound)
        {
            throw new ResourceNotFound();
        }
    }

    public List<Ticket> GetTicketsByUserID(string userIWantTicketsFor)
    {
        string byUserQueryWithID = "select * from AutumnERS.tickets where author_fk = " + userIWantTicketsFor + ";";
        List<Ticket> TicketsFromPeepIWant = new List<Ticket>(); 
        GetTickets(byUserQueryWithID);
        return TicketsFromPeepIWant;
    }

    public List<Ticket> GetTicketsByStatus()
    {
        Console.WriteLine("Choose a status.");
        Console.WriteLine("[1] Approved");
        Console.WriteLine("[2] Denied");
        Console.WriteLine("[3] Pending");            
        string thisStatus = Console.ReadLine();
        switch (thisStatus)
        {
            case "1": // Approved
                thisStatus = "Approved";
                break;
            case "2": // Denied
                thisStatus = "Denied";                   
                break;  
            case "3": // Pending
                thisStatus = "Pending";                    
                break;                    
            default:
                Console.WriteLine("What kind of nonsense was that?");
                break;
        }         
        string thoseStatusTickets = "select * from AutumnERS.tickets where status = '" + thisStatus + "';";
        List<Ticket> statusTickets = new List<Ticket>();
        GetTickets(thoseStatusTickets);
        return statusTickets;
    }  

    public List<Ticket> GrabTicketByTicketID(string ticketID)
    {
        string byTicketID = "select * from AutumnERS.tickets where ticketID = " + ticketID + ";";
        List<Ticket> ticketIWant = new List<Ticket>(); 
        GetTickets(byTicketID);
        return ticketIWant;        
    }

    public List<Ticket> ResolveThisTicket(string ticketID, User CurrentUserIn)
    {
        // CurrentUser info
        int myIDint = CurrentUserIn.userID;
        // model of how to use it
        //myTickets.GetTicketsByUserID(myIDstring);
        // ticket info follows
        List<Ticket> ticketToUpdate = new List<Ticket>();

        Console.WriteLine("Approve or Deny?");
        Console.WriteLine("[1] Approve");
        Console.WriteLine("[2] Deny");
        string newStatus = Console.ReadLine();
        switch (newStatus)
        {
            case "1": // Approve
                newStatus = "Approved";
                break;
            case "2": // Deny
                newStatus = "Denied";                   
                break;                   
            default:
                Console.WriteLine("What kind of nonsense was that?");
                break;
        } 

        string updateTicketStatement = "UPDATE AutumnERS.tickets SET status = @status, resolver_fk = @myIDint WHERE ticketID = @ticketID;";
        //string updateTicketStatement = "UPDATE AutumnERS.tickets SET status = '" + newStatus + "', resolver_fk =  WHERE ticketID = " + ticketID + ";";
        // UPDATE AutumnERS.tickets SET status = 'Approved' WHERE ticketID = 16;
        SqlConnection makeConnection = _connectionFactory.GetConnection();
        SqlCommand updateTicket = new SqlCommand(updateTicketStatement, makeConnection);
        
        updateTicket.Parameters.AddWithValue("@ticketID", ticketID);
        updateTicket.Parameters.AddWithValue("@myIDint", myIDint);
        updateTicket.Parameters.AddWithValue("@status", newStatus);

        try
        {
            makeConnection.Open();
            int itWorked = updateTicket.ExecuteNonQuery();
            makeConnection.Close();
            if (itWorked != 0)
            {
                Console.WriteLine("Ticket updated.");
                List<Ticket> updatedTicket = GrabTicketByTicketID(ticketID);
                return updatedTicket;
            }
            else
            {
                Console.WriteLine("Sorry, that didn't seem to work.");
                throw new ResourceNotFound();
            }
        }
        catch (ResourceNotFound e)
        {
            Console.WriteLine(e.Message);
        }

        return ticketToUpdate;
    }

    public List<Ticket> CreateTicket(User CurrentUser)
    {
        // CurrentUser info
        int myIDint = CurrentUser.userID;
        string myIDstring = myIDint.ToString();

        // Ticket info
        Console.WriteLine("What is it?");
        string ticketDescription = Console.ReadLine();
        Console.WriteLine("How much?");
        string ticketCost = Console.ReadLine();
        Console.WriteLine("Attempting to create Ticket");

        List<Ticket> AllMyTickets = new List<Ticket>();

        string createTicketSQL = "insert into AutumnERS.tickets (author_fk, description, amount) values (@author, @description, @amount);";

        SqlConnection makeConnection = _connectionFactory.GetConnection();
        SqlCommand createThisTicket = new SqlCommand(createTicketSQL, makeConnection);

        createThisTicket.Parameters.AddWithValue("@author", myIDstring);
        createThisTicket.Parameters.AddWithValue("@description", ticketDescription);
        createThisTicket.Parameters.AddWithValue("@amount", ticketCost);

        try
        {
            makeConnection.Open();
            int itWorked = createThisTicket.ExecuteNonQuery();
            makeConnection.Close();
            if (itWorked !=0)
            {
                Console.WriteLine("Request submitted successfully. Good luck!");
                AllMyTickets = GetTicketsByUserID(myIDstring);
                // Return myTickets;
                //throw new UsernameNotAvailable();
            }
        }
        catch (UsernameNotAvailable e)
        {
            Console.WriteLine(e.Message);
        }
        return AllMyTickets;
    }

}
