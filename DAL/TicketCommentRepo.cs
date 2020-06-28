using BugTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTrackerApp.DAL
{
    public class TicketCommentRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public void Add(TicketComment ticketComment)
        {
            db.TicketComments.Add(ticketComment);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var commentToDelete = db.TicketComments.Find(id);
            db.TicketComments.Remove(commentToDelete);
            db.SaveChanges();
        }

        public TicketComment Get(int id)
        {
            return db.TicketComments.Find(id);

        }

        public IList<TicketComment> Get()
        {
            return db.TicketComments.ToList();
        }
        
        public void Edit(TicketComment ticketComment)
        {
            db.Entry(ticketComment).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}