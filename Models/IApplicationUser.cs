using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTrackerApp.Models
{
    public interface IApplicationUser
    {
        ICollection<ProjectUser> ProjectUsers { get; set; }
        ICollection<TicketAttachment> TicketAttachments { get; set; }
        ICollection<TicketComment> TicketComments { get; set; }
        ICollection<TicketHistory> TicketHistories { get; set; }
        ICollection<TicketNotification> TicketNotifications { get; set; }

        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager);
    }
}