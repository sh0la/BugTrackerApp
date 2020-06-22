using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BugTrackerApp.Models
{
    public class TicketDAL
    {
        ApplicationDbContext db = new ApplicationDbContext();
        

        public void Add(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }

        public Ticket GetTicket(int Id)
        {
            return db.Tickets.Find(Id);

        }

        public void Edit(Ticket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
            db.SaveChanges();
            
        }

    }
}