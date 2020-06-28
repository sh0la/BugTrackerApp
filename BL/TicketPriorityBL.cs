using BugTrackerApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models;


namespace BugTrackerApp.BL
{
    public class TicketPriorityBL
    {
        TicketPriorityRepo _repo;

        public TicketPriorityBL()
        {
            _repo = new TicketPriorityRepo();
        }

        public void CreatePriority(string name)
        {
            var ticketPriority = new TicketPriority();
            ticketPriority.Name = name;
            _repo.Add(ticketPriority);
        }

        public void EditPriorityName(int Id)
        {
            _repo.Edit(Id);
        }

        public void EditPriority(TicketPriority ticketPriority)
        {
            _repo.Edit(ticketPriority);
        }

        public IList<TicketPriority> GetTicketPriorities()
        {
            return _repo.Get();
        }


        public void DeleteTicketPriorityLabel(int Id)
        {
            _repo.Delete(Id);
        }


    }
}