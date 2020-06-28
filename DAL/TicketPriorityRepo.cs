using BugTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTrackerApp.DAL
{
    public class TicketPriorityRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Add(TicketPriority ticketPriority)
        {
            db.TicketPriorities.Add(ticketPriority);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var currentTicketPriority = db.TicketPriorities.Find(Id);
            db.TicketPriorities.Remove(currentTicketPriority);

        }

        public void Edit(int Id)
        {
            var currentTicketPriority = db.TicketPriorities.Find(Id);
            db.Entry(currentTicketPriority).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Edit(TicketPriority currentTicketPriority)
        {
            db.Entry(currentTicketPriority).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IList<TicketPriority> Get()
        {
            return db.TicketPriorities.ToList();
        }
    }
}