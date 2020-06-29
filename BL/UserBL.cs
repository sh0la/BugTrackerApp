using BugTrackerApp.BL;
using BugTrackerApp.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
{
    public class UserBL
    {
        private UserDAL _repo;
        private ProjectUserBL _puRepo;
        public UserBL()
        {
            _repo = new UserDAL();
            _puRepo = new ProjectUserBL();
        }

        public void CreateRole(string roleName)
        {
            _repo.CreateRole(roleName);
        }

        public void DeleteRole(string roleName)
        {
            _repo.DeleteRole(roleName);
        }

        public bool CheckIfUserIsInARole(string userId, string roleName)
        {
            return _repo.UserIsInRole(userId, roleName);

        }

        public bool RemoveAUserFromARole (string userId, string roleName)
        {
            return _repo.RemoveUserFromRole(userId, roleName);
        }

        public void AddAUserToARole(string userId, string roleName)
        {
             _repo.AddUserToRole(userId, roleName);
        }

        public void RemoveAUser(ApplicationUser user)
        {
            _repo.RemoveUser(user);
           
        }

        public void RemoveAProjectManagerFromAProject(Project project, ApplicationUser newProjectManager)
        {
            _repo.RemoveUserFromProject(project, newProjectManager);
        }

        public void AddAProjectManagerToAProject(int projectId, string userId )
        {
            _puRepo.CreateProjectUser(projectId, userId);
        }

        public void AddDeveloperToATicket(Ticket ticket, ApplicationUser developer)
        {
            _repo.ChangeDeveloperOnTicket(ticket, developer);
        }

        public void RemoveDeveloperFromATicket(Ticket ticket, ApplicationUser developer)
        {
            _repo.ChangeDeveloperOnTicket(ticket, developer);
        }

        public ApplicationUser GetAUser(string Id)
        {
            return _repo.GetUser(Id);
        }

        public IList<ApplicationUser> GetAllUsers()
        {
            return _repo.GetAllUsers();

        }

        public List<Project> GetProjectsOfUser(string id)
        {
            return _repo.GetUserProjects(id);
        }

        public List<Ticket> GetAllTicketsOfAllProjectsOfAUser(string id)
        {
            return GetProjectsOfUser(id).SelectMany(p => p.Tickets).ToList();
        }

        public List<Ticket> GetAllTicketsUserIsAssignedTo(string id)
        {
            ApplicationUser user = _repo.GetUser(id);
            return user.AssignedToUserTickets.ToList();
        }

        public List<Ticket> GetOwnedTickets(string id)
        {
            ApplicationUser user = _repo.GetUser(id);
            return user.OwnerTickets.ToList();
        }

        public List<ApplicationUser> GetAllUsersInRole(string roleName)
        {
            return _repo.GetAllUsers().Where(u => CheckIfUserIsInARole(u.Id, roleName)).ToList();
        }

        public List<IdentityRole> AllRolesOfAUser(string id)
        {
            return _repo.GetAllRolesOfUser(id);
        }

        public List<IdentityRole> GetRoles()
        {
            return _repo.GetRoles();
        }



    }
}