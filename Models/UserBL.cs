using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
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

        public void RemoveAProjectManagerFromAProject(ApplicationUser oldProjectManager, Project project, ApplicationUser newProjectManager)
        {
            _repo.RemoveUserFromProject(oldProjectManager, project, newProjectManager);
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