using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.DAL
{
    public class TicketStatusRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Add(TicketStatus status)
        {
            db.TicketStatuses.Add(status);
            db.SaveChanges();
        }

        public TicketStatus Get(int id)
        {
            return db.TicketStatuses.Find(id);
        }

        public void Delete(int id)
        {
            TicketStatus status = db.TicketStatuses.Find(id);
            db.TicketStatuses.Remove(status);
            db.SaveChanges();
        }
    }
}