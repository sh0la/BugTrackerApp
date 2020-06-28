using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.DAL
{
    public class TicketHistoryRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Add(TicketHistory ticketHistory)
        {
            
            db.TicketHistories.Add(ticketHistory);
            db.SaveChanges();
            
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