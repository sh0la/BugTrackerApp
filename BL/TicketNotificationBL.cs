using BugTrackerApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models;

namespace BugTrackerApp.BL
{
    public class TicketNotificationBL
    {
        TicketNotificationRepo _repo;

        public TicketNotificationBL(TicketNotificationRepo repo)
        {
            _repo = new TicketNotificationRepo();
        }


        public void CreateNotification(Ticket ticket, ApplicationUser user)
        {
            var ticketNotification = new TicketNotification();
            ticketNotification.ApplicationUserId = user.Id;
            ticketNotification.TicketId = ticket.Id;
            _repo.Add(ticketNotification);
            
        }

        public IList<TicketNotification> GetNotifications()
        {
            return _repo.GetNotifications();
        }
    }
}