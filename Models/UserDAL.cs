using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
{
    public class UserDAL
    {
        static ApplicationDbContext db = new ApplicationDbContext();
        static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
        static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

        public void CreateRole(string roleName)

        {
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public void DeleteRole(string roleName)
        {
            // can we delete default roles?
            if (roleManager.RoleExists(roleName))
            {
                roleManager.Delete(new IdentityRole { Name = roleName });
            }
        }

        public bool UserIsInRole(string userId, string roleName)
        {
            return userManager.IsInRole(userId, roleName);
        }

        public bool RemoveUserFromRole(string userId, string roleName)
        {
            if (UserIsInRole(userId, roleName))
            {
                userManager.RemoveFromRole(userId, roleName);
                return true;
            }

            return false;
        }

        public void AddUserToRole(string roleName, string userName)
        {
            IdentityRole role = roleManager.FindByName(roleName);
            ApplicationUser user = userManager.FindByName(userName);
            if (role != null && user != null && !userManager.IsInRole(user.Id, roleName))
            {
                userManager.AddToRole(user.Id, roleName);
            }
            
        }

        public void RemoveUser(ApplicationUser user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void AddUserToAProject(Project project, ApplicationUser newUser)
        {
            var currentProject = db.ProjectUsers.Find(project.Id);
            currentProject.ApplicationUserId = newUser.Id;
            db.SaveChanges();
        }

        public void RemoveUserFromProject(Project project, ApplicationUser newUser)
        {
            var currentProject = db.ProjectUsers.Find(project.Id);
            currentProject.ApplicationUserId = newUser.Id;
            db.SaveChanges();
        }

        public void ChangeDeveloperOnTicket(Ticket ticket, ApplicationUser user)
        {
            var currentTicket = db.Tickets.Find(ticket.Id);
            currentTicket.AssignedToUserId = user.Id;
            db.SaveChanges();
        }




        public IList<ApplicationUser> GetAllUsers()
        {
            return db.Users.ToList();
        }
    }
}