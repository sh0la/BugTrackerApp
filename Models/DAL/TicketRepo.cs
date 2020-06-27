using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.DAL
{
    public class TicketRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public List<Ticket> GetAll()
        {
            return db.Tickets.ToList();
        }

        public void Add(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }

        public void Edit(Ticket ticket)
        {

        }


    }
}