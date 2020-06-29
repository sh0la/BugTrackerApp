using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.VM
{
    public class userPermisionsVM
    {
        public ApplicationUser user { get; set; }
        public List<IdentityRole> RolesUserIsIn { get; set; }
        public List<IdentityRole> RolesUserIsNotIn { get; set; }
    }
}