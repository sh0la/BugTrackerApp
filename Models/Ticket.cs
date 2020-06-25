using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace BugTrackerApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        [Display(Name ="Ticket Type")]
        public int? TicketTypeId { get; set; }
        public virtual TicketType TicketType { get; set; }
        [Display(Name = "Ticket Priority")]
        public int? TicketPriorityId { get; set; }
        public virtual TicketPriority TicketTypePriority { get; set; }
        [Display(Name = "Ticket Status")]
        public int? TicketStatusId { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        [Display(Name = "Submitted By")]
        public string OwnerUserId { get; set; }
        public virtual ApplicationUser OwnerUser { get; set; }
        [Display(Name = "Developer Assigned To")]
        public string AssignedToUserId { get; set; }
        public virtual ApplicationUser AssignedToUser { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
        public virtual ICollection<TicketNotification> TicketNotifications { get; set; }

        public Ticket()
        {
            this.Created = DateTime.Now;
            this.TicketComments = new HashSet<TicketComment>();
            this.TicketAttachments = new HashSet<TicketAttachment>();
            this.TicketHistories = new HashSet<TicketHistory>();
            this.TicketNotifications = new HashSet<TicketNotification>();
        }

        public Ticket(DateTime Created)
        {
            this.Created = Created;
        }
      
    }

}