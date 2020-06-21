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

        public static void CreateAdminRole()
        {
            if(!roleManager.RoleExists("Administrator")) 
            {
                roleManager.Create(new IdentityRole("Administrator"));
                db.SaveChanges();
            }
            
        }

        public static void CreateProjectManagerRole()
        {
            if (!roleManager.RoleExists("Project Manager"))
            {
                roleManager.Create(new IdentityRole("Project Manager"));
                db.SaveChanges();
            }

        }

        public static void CreateDeveloperRole()
        {
            if (!roleManager.RoleExists("Developer"))
            {
                roleManager.Create(new IdentityRole("Developer"));
                db.SaveChanges();
            }

        }

        public static void CreateSubmitterRole()
        {
            if (!roleManager.RoleExists("Submitter"))
            {
                roleManager.Create(new IdentityRole("Submitter"));
                db.SaveChanges();
            }

        }

        public static void CreateGlobalAdminRole()
        {
            if (!roleManager.RoleExists("Global Admin"))
            {
                roleManager.Create(new IdentityRole("Global Admin"));
                db.SaveChanges();
            }

        }

        public static void CreateRole(string roleName)
        {
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole
                {
                    Name = roleName
                });

                db.SaveChanges();
            }
        }

        public static void DeleteRole(string roleName)
        {
            // can we delete default roles?
            if (roleManager.RoleExists(roleName))
            {
                roleManager.Delete(new IdentityRole { Name = roleName });
            }
        }

        public static bool UserIsInRole(string userId, string roleName)
        {
            return userManager.IsInRole(userId, roleName);
        }

        public static bool RemoveUserFromRole(string userId, string roleName)
        {
            if (UserIsInRole(userId, roleName))
            {
                userManager.RemoveFromRole(userId, roleName);
                return true;
            }

            return false;
        }

        public static void AddUserToRole(string roleName, string userName)
        {
            IdentityRole role = roleManager.FindByName(roleName);
            ApplicationUser user = userManager.FindByName(userName);
            if (role != null && user != null && !userManager.IsInRole(user.Id, roleName))
            {
                userManager.AddToRole(user.Id, roleName);
            }
            db.SaveChanges();
        }

        //???
        public static void CreateUser(string name, string email, string password)
        {
            var user = new ApplicationUser();
            user.UserName = name;
            user.Email = email;
            userManager.CreateIdentityAsync(user, password);
   
            db.SaveChanges();

        }

        public static void RemoveUser(ApplicationUser user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }


    }
}