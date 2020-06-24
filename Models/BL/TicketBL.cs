using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
{
    public class TicketBL
    {
        private readonly ITicketRepo _repo;

        public TicketBL(ITicketRepo repo)
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