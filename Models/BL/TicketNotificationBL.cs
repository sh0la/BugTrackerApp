using BugTrackerApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
{
    public class TicketNotificationBL
    {
        TicketNotificationRepo _repo;

        public TicketNotificationBL(TicketNotificationRepo repo)
        {
            _repo = repo;
        }


        public void AddNotification(Ticket ticket, ApplicationUser user)
        {
            _repo.Add(ticket, user);
        }

    }
}