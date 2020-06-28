using BugTrackerApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models;


namespace BugTrackerApp.BL
{
    public class TicketHistoryBL
    {
        TicketHistoryRepo _repo;

        public TicketHistoryBL()
        {
            _repo = new TicketHistoryRepo();
        }

        public TicketHistory GetATicketHistory(int Id)
        {
            return _repo.Get(Id);
        }

        public IList<TicketHistory> GetTicketHistories()
        {
            return _repo.Get();
        }

        public void CreateTicketHistory(Ticket ticket)
        {
            var ticketHistory = new TicketHistory();
            //var currentTicketHistory = _repo.TicketHistories.Find(ticket.Id);
            //Get the last history
            //compare the properties
            //update the new history

        }
    }
}