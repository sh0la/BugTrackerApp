using BugTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.DAL
{
    public class TicketNotificationRepo
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        
        public void Add(TicketNotification ticketNotification)
        {
            db.TicketNotifications.Add(ticketNotification);
            db.SaveChanges();
        }

        public IList<TicketNotification> GetNotifications()
        {
            return db.TicketNotifications.ToList();

        }





    }
}