using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.DAL
{
    public class TicketNotificationRepo
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        
        public void Add(Ticket ticket, ApplicationUser user)
        {
            var ticketNotification = new TicketNotification();
            ticketNotification.ApplicationUserId = user.Id;
            ticketNotification.TicketId = ticket.Id;
            db.SaveChanges();
        }

        public IList<TicketNotification> GetNotifications()
        {
            return db.TicketNotifications.ToList();

        }





    }
}