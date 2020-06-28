using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.VM
{
    public class UserRolesVM
    {
        public List<ApplicationUser> Admins { get; set; }
        public List<ApplicationUser> PMs { get; set; }
        public List<ApplicationUser> Devs { get; set; }
        public List<ApplicationUser> Submitters { get; set; }
    }
}