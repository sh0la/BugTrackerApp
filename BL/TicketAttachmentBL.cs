using BugTrackerApp.Models.DAL;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models;


namespace BugTrackerApp.BL
{
    public class TicketAttachmentBL
    {
        private TicketAttachmentRepo _repo;

        public TicketAttachmentBL()
        {
            _repo = new TicketAttachmentRepo();
        }

        public void Add(TicketAttachment attachment)
        {
            if (attachment != null)
                _repo.Add(attachment);
        }

        public void AddNewTicketAttachment(int ticketId, string userId, string filePath, string description)
        {
            TicketAttachment ticketAttachment = new TicketAttachment();
            ticketAttachment.ApplicationUserId = userId;
            ticketAttachment.TicketId = ticketId;
            ticketAttachment.FilePath = filePath;
            ticketAttachment.Description = description;

            _repo.Add(ticketAttachment);
        }

        public TicketAttachment GetTicketAttachment(int id)
        {
            TicketAttachment ticketAttachment = _repo.Get(id);
            
            if (ticketAttachment == null)
            {
                throw new Exception("Not Found");
            }

            return ticketAttachment;
        }

        public void Delete(int id)
        {
            TicketAttachment attachment = _repo.Get(id);

            if (attachment != null)
                _repo.Delete(id);
        }
    }
}