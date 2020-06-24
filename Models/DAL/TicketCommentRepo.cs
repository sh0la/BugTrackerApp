using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.DAL
{
    public class TicketCommentRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Create(Ticket ticket, ApplicationUser user, string comment)
        {
            var ticketComment = new TicketComment();
            ticketComment.TicketId = ticket.Id;
            ticketComment.Comment = comment;
            ticketComment.ApplicationUserId = user.Id;
        }

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
        
    }
}