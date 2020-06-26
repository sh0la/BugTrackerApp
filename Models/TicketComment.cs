using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
{
    public class TicketComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public TicketComment()
        {
            this.Created = DateTime.Now;
        }

        public TicketComment(DateTime created)
        {
            this.Created = created;
        }
    }


}