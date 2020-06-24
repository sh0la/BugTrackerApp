using BugTrackerApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
{
    public class UserBL
    {
        private UserDAL _repo;

        public UserBL(UserDAL repo)
        {
            _repo = repo;
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

        public void AddAProjectManagerToAProject(Project project, ApplicationUser newProjectManager)
        {
            _repo.AddUserToAProject(project, newProjectManager);
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
            var users = _repo.GetAllUsers();
            return users.FirstOrDefault(u => u.Id == Id);
           
        }

        public IList<ApplicationUser> GetAllUsers()
        {
            return _repo.GetAllUsers();

        }

       
    }
}