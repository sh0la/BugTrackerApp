using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
{
    public class ProjectUserViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}