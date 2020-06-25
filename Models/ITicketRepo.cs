using System.Collections;
using System.Collections.Generic;

namespace BugTrackerApp.Models
{
    public interface ITicketRepo
    {
        void Add(Ticket ticket);
        void Edit(Ticket ticket);
        Ticket Get(int Id);
        IList<Ticket> Get();
    }
}