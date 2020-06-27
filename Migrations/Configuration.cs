namespace BugTrackerApp.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;
    using System.Web.Security;
    using BugTrackerApp.Models;
    using BugTrackerApp.Models.BL;
    using BugTrackerApp.Models.DAL;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.VisualBasic.ApplicationServices;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTrackerApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BugTrackerApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            string[] roles = new string[] { "Administrator", "Project Manager", "Developer", "Submitter" };
            foreach (var role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }


            //var a = new RoleStore<IdentityRole> { Roles = "Admin"}
            //var admin = new IdentityUserRole { RoleId = "admin", UserId = "peter" };

            var resolved1 = new TicketStatus { Id = 1, Name = "resolved" };
            var resolved2 = new TicketStatus { Id = 1, Name = "unresolved" };
            var resolved3 = new TicketStatus { Id = 1, Name = "unresolved" };
            var resolved4 = new TicketStatus { Id = 1, Name = "resolved" };
            var resolved5 = new TicketStatus { Id = 1, Name = "resolved" };

            context.TicketStatuses.AddOrUpdate(resolved1, resolved2, resolved3, resolved4, resolved5);

            var priority1 = new TicketPriority { Id = 1, Name = "high" };
            var priority2 = new TicketPriority { Id = 1, Name = "medium" };
            var priority3 = new TicketPriority { Id = 1, Name = "high" };
            var priority4 = new TicketPriority { Id = 1, Name = "low" };
            var priority5 = new TicketPriority { Id = 1, Name = "low" };

            context.TicketPriorities.AddOrUpdate(priority1, priority2, priority3, priority4, priority5);

            
            var type1 = new TicketType { Id = 1, Name = "high" };
            var type2 = new TicketType { Id = 1, Name = "medium" };
            var type3 = new TicketType { Id = 1, Name = "high" };
            var type4 = new TicketType { Id = 1, Name = "low" };
            var type5 = new TicketType { Id = 1, Name = "low" };

            context.TicketTypes.AddOrUpdate(type1, type2, type3, type4, type5);


            var css = new Project { Id = 1, Name = "CSS"};
            var html = new Project { Id = 1, Name = "html" };
            var js = new Project { Id = 1, Name = "js" };
            var product = new Project { Id = 1, Name = "product" };
            var aboutUs = new Project { Id = 1, Name = "aboutUs" };

            context.Projects.AddOrUpdate(css, html, js, product, aboutUs);

           
            var peter = new ApplicationUser { 
                Id = "peter", UserName = "Peter", Email = "test@test.com", PasswordHash = "ABCabc123!"};
            var mike = new ApplicationUser { 
                Id = "mike", UserName = "mike", Email = "mike@test.com",
                PasswordHash = "ABCabc123!"
            };
            var erfun = new ApplicationUser { 
                Id = "erfun", UserName = "erfun", Email = "erfun@test.com",
                PasswordHash = "ABCabc123!"
            };
            var john = new ApplicationUser { 
                Id = "john", UserName = "john", Email = "john@test.com",
                PasswordHash = "ABCabc123!"
            };
            var shola = new ApplicationUser { 
                Id = "shola", UserName = "shola", Email = "shola@test.com",
                PasswordHash = "ABCabc123!"
            };
            var jasmeet = new ApplicationUser { 
                Id = "jasmeet", UserName = "jasmeet", Email = "jasmeet@test.com",
                PasswordHash = "ABCabc123!"
            };
            var zane = new ApplicationUser { 
                Id = "zane", UserName = "zane", Email = "zane@test.com",
                PasswordHash = "ABCabc123!"
            };

            context.Users.AddOrUpdate(peter, mike, erfun, jasmeet, zane, shola);

            var pUser1 = new ProjectUser { Id = 1, ApplicationUserId = "erfun", ProjectId = 1 };
            var pUser2 = new ProjectUser { Id = 2, ApplicationUserId = "shola", ProjectId = 2 };
            var pUser3 = new ProjectUser { Id = 3, ApplicationUserId = "jasmeet", ProjectId = 2 };
            var pUser4 = new ProjectUser { Id = 4, ApplicationUserId = "zane", ProjectId = 4 };
            var pUser5 = new ProjectUser { Id = 5, ApplicationUserId = "shola", ProjectId = 3 };

            context.ProjectUsers.AddOrUpdate(pUser1, pUser2, pUser3, pUser4, pUser5);


            var error = new Ticket
            {
                Id = 1,
                Title = "404 error",
                Description = "There is a 404 error",
                Created = DateTime.Now,
                ProjectId = 1,
                OwnerUserId = "peter",
                AssignedToUserId = "zane"
            };

            var notBlue = new Ticket
            {
                Id = 2,
                Title = "Color is not blue",
                Description = "The color is ava blue instead of sky blue",
                Created = DateTime.Now,
                ProjectId = 1,
                OwnerUserId = "mike",
                AssignedToUserId = "jasmeet"
            };

            var breakingCSS = new Ticket
            {
                Id = 3,
                Title = "breaking CSS",
                Description = "the css of the homepage is breaking",
                Created = DateTime.Now,
                ProjectId = 1,
                OwnerUserId = "peter",
                AssignedToUserId = "erfun"
            };

            var popUp = new Ticket
            {
                Id = 4,
                Title = "extension of pop",
                Description = "The pop up is not showing on the about us page",
                Created = DateTime.Now,
                ProjectId = 2,
                OwnerUserId = "peter",
                AssignedToUserId = "zane"
            };

            var crashing = new Ticket
            {
                Id = 5,
                Title = "Crashing product page",
                Description = "THe product page for the tom product keeps crashing",
                Created = DateTime.Now,
                ProjectId = 3,
                OwnerUserId = "peter",
                AssignedToUserId = "shola"
            };

            context.Tickets.AddOrUpdate(crashing, popUp, error, notBlue, breakingCSS);


            var ticketcomment1 = new Models.TicketComment { Id = 1, Comment = "It doesnt work on the Brave browser", Created = DateTime.Now, ApplicationUserId = "jasmeet", TicketId = 2 };
            var ticketcomment2 = new Models.TicketComment { Id = 2, Comment = "use the developer tools", Created = DateTime.Now, ApplicationUserId = "erfun", TicketId = 4 };
            var ticketcomment3 = new Models.TicketComment { Id = 1, Comment = "Restarting the computer removes everything", Created = DateTime.Now, ApplicationUserId = "john", TicketId = 3 };
            var ticketcomment4 = new Models.TicketComment { Id = 1, Comment = "They share the hex", Created = DateTime.Now, ApplicationUserId = "peter", TicketId = 1 };
            var ticketcomment5 = new Models.TicketComment { Id = 1, Comment = "We have to test with all major browsers", Created = DateTime.Now, ApplicationUserId = "mike", TicketId = 2 };

            context.TicketComments.AddOrUpdate(ticketcomment1, ticketcomment2, ticketcomment3, ticketcomment4, ticketcomment5);


            var notification1 = new TicketNotification { Id = 1, ApplicationUserId = "mike", TicketId = 1 };
            var notification2 = new TicketNotification { Id = 2, ApplicationUserId = "john", TicketId = 2 };
            var notification3 = new TicketNotification { Id = 3, ApplicationUserId = "peter", TicketId = 2 };
            var notification4 = new TicketNotification { Id = 4, ApplicationUserId = "mike", TicketId = 4 };
            var notification5 = new TicketNotification { Id = 5, ApplicationUserId = "shola", TicketId = 3 };

            context.TicketNotifications.AddOrUpdate(notification1, notification2, notification3, notification4, notification5);


            var attachment1 = new TicketAttachment { Id = 1, Created = DateTime.Now, ApplicationUserId = "peter", TicketId = 2, Description = "mockup of solution", FilePath = "C://Repo/Solutions", FileUrl="mock.jpg" };
            var attachment2 = new TicketAttachment { Id = 2, Created = DateTime.Now, ApplicationUserId = "john", TicketId = 1, Description = "seed for document", FilePath = "C://Repo/Solutions", FileUrl = "test.txt" };
            var attachment3 = new TicketAttachment { Id = 3, Created = DateTime.Now, ApplicationUserId = "mike", TicketId = 5, Description = "error generated", FilePath = "C://Repo/Solutions", FileUrl = "fault.txt" };
            var attachment4 = new TicketAttachment { Id = 4, Created = DateTime.Now, ApplicationUserId = "zane", TicketId = 2, Description = "my screenshot", FilePath = "C://Repo/Solutions", FileUrl = "mock2.jpg" };
            var attachment5 = new TicketAttachment { Id = 5, Created = DateTime.Now, ApplicationUserId = "jasmeet", TicketId = 3, Description = "example of login mock", FilePath = "C://Repo/Solutions", FileUrl = "0090asdf.jpg" };

            context.TicketAttachments.AddOrUpdate(attachment1, attachment2, attachment3, attachment4, attachment5);




        }
    }
}
