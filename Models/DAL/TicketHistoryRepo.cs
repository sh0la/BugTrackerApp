using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.DAL
{
    public class TicketHistoryRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Add(Ticket ticket)
        {
            var ticketHistory = new TicketHistory();
            var currentTicketHistory = db.TicketHistories.Find(ticket.Id);
            //Get the last history
            //compare the properties
            //update the new history
            
        }

        public TicketHistory Get(int Id)
        {
            return db.TicketHistories.Find(Id);
        }

        public IList<TicketHistory> Get()
        {
            return db.TicketHistories.ToList();
        }

    

       
    }
}