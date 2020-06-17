using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }

        public Project()
        {
            this.Tickets = new HashSet<Ticket>();
            this.ProjectUsers = new HashSet<ProjectUser>();
        }
    }
}