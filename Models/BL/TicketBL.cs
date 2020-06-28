using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models.DAL;


namespace BugTrackerApp.Models.BL
{
    public class TicketBL
    {
        private TicketRepo _repo;

        public TicketBL()
        {
            _repo = new TicketRepo();
        }

        public Ticket GetTicket(int Id)
        {
            return _repo.Get(Id);
        }

        public IList<Ticket> GetAllTickets()
        {
            return _repo.GetAll();
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

        public List<Ticket> OwnedTickets(string id)
        {
            return _repo.GetOwnedTicktsForUser(id);
        }
    }
}