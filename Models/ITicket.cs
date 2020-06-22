namespace BugTrackerApp.Models
{
    public interface ITicket
    {
        void Add(Ticket ticket);
        void Edit(Ticket ticket);
        Ticket GetTicket(int Id);
    }
}