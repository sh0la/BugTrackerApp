using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
{
    public class TicketBL
    {
        private readonly ITicket _repo;

        public TicketBL(ITicket repo)
        {
            _repo = repo;
        }

        public Ticket GetTicket(int Id)
        {
            return _repo.GetTicket(Id);

        }

        public void AddTicket(Ticket ticket)
        {
            if (ticket != null)
                _repo.Add(ticket);
        }

        public void EditTicket(int Id)
        {
            var ticket = _repo.GetTicket(Id);
            _repo.Edit(ticket);
        }
    }
}