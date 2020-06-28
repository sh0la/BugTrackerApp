using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace BugTrackerApp.Models.DAL
{
    public class TicketTypeRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public IList<TicketType> GetAll()
        {
            return db.TicketTypes.ToList();
        }

        public void Add(TicketType ticketType)
        {
            db.TicketTypes.Add(ticketType);
            db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var currentTicketType = db.TicketTypes.Find(Id);
            db.TicketTypes.Remove(currentTicketType);
            db.SaveChanges();
        }

        public void Delete(TicketType ticketType)
        {
            db.TicketTypes.Remove(ticketType);
        }

        public void Edit(TicketType ticketType)
        {
            db.Entry(ticketType).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}