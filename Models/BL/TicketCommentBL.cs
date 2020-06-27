using BugTrackerApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
{
    public class TicketCommentBL
    {
        TicketCommentRepo _repo;

        public TicketCommentBL()
        {
            _repo = new TicketCommentRepo();
        }

        public void CreateTicketComment(Ticket ticket, ApplicationUser user, string comment)
        {
            var ticketComment = new TicketComment();
            ticketComment.TicketId = ticket.Id;
            ticketComment.Comment = comment;
            ticketComment.ApplicationUserId = user.Id;
            _repo.Add(ticketComment);
        }

        public TicketComment GetATicketComment(int Id)
        {
            return _repo.Get(Id);
        }

        public IList<TicketComment> GetAListOfComment()
        {
            return _repo.Get();
        }

        public void DeleteAComment(int Id)
        {
            _repo.Delete(Id);
            
        }

        public void Edit(TicketComment ticketComment)
        {
            _repo.Edit(ticketComment);
        }
    }
}