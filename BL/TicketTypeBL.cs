using BugTrackerApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models;


namespace BugTrackerApp.BL
{
    public class TicketTypeBL
    {
        TicketTypeRepo _repo;

        public TicketTypeBL()
        {
            _repo = new TicketTypeRepo();
        }

        public IList<TicketType> GetAllTicketTypes()
        {
            return _repo.GetAll();
        }

        public void CreateTicketTypeName(string name)
        {
            var ticketType = new TicketType { Name = name };
            _repo.Add(ticketType);
        }

        public void EditTicketTypeName(TicketType ticketType)
        {
            _repo.Edit(ticketType);
        }

        public void DeleteTicketTypeName(int Id)
        {
            _repo.Delete(Id);
        }

        public void DeleteTicketTypeName(TicketType ticketType)
        {
            _repo.Delete(ticketType);
        }



    }
}