using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models.DAL;


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
            return _repo.Get(Id);
        }

        public IList<Ticket> GetAllTickets()
        {
            return _repo.Get();
        }

        public void AddTicket(Ticket ticket)
        {
            if (ticket != null)
                _repo.Add(ticket);
        }

        public void EditTicket(int Id)
        {
            var ticket = _repo.Get(Id);
            _repo.Edit(ticket);
        }
    }
}