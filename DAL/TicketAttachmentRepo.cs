using BugTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.DAL
{
    public class TicketAttachmentRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public void Add(TicketAttachment ticketAttachment)
        {
            db.TicketAttachments.Add(ticketAttachment);
            db.SaveChanges();
        }

        public TicketAttachment Get(int id)
        {
            return db.TicketAttachments.Find(id);
        }

        public void Delete(TicketAttachment ticketAttachment)
        {
            db.TicketAttachments.Remove(ticketAttachment);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            TicketAttachment ticketAttachment = db.TicketAttachments.Find(id);
            db.TicketAttachments.Remove(ticketAttachment);
            db.SaveChanges();
        }
    }
}