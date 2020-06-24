using BugTrackerApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
{
    public class TicketStatusBL
    {
        private TicketStatusRepo _repo = new TicketStatusRepo();

        public void Add(TicketStatus status)
        {
            if (status != null)
                _repo.Add(status);
        }

        public void Create(string name)
        {
            TicketStatus status = new TicketStatus();
            status.Name = name;
            _repo.Add(status);
        }

        public TicketStatus Get(int id)
        {
            TicketStatus status = _repo.Get(id);

            if (status == null)
            {
                throw new Exception("Not Found");
            }

            return status;
        }

        public void Delete(int id)
        {
            TicketStatus status = _repo.Get(id);

            if (status != null)
                _repo.Delete(id);
        }
    }
}