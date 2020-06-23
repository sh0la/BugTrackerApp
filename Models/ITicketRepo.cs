namespace BugTrackerApp.Models
{
    public interface ITicketRepo
    {
        void Add(Ticket ticket);
        void Edit(Ticket ticket);
        Ticket GetTicket(int Id);
    }
}