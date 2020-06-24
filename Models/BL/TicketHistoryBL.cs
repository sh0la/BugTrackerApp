using BugTrackerApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
{
    public class TicketHistoryBL
    {
        TicketHistoryRepo _repo;

        public TicketHistoryBL(TicketHistoryRepo repo)
        {
            _repo = repo;
        }

        public TicketHistory GetATicketHistory(int Id)
        {
            return _repo.Get(Id);
        }

        public IList<TicketHistory> GetTicketHistories()
        {
            return _repo.Get();
        }

    }
}