using BugTrackerApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models;

namespace BugTrackerApp.BL
{
    public class ProjectUserBL
    {
        private ProjectUserRepo _repo;

        public ProjectUserBL()
        {
            _repo = new ProjectUserRepo();
        }

        public ProjectUser GetProjectUser(int id)
        {
            return _repo.Get(id);
        } 

        public void CreateProjectUser(int projectId, string userId)
        {
            if (!_repo.UserInProject(userId, projectId))
            {
                var projectUser = new ProjectUser();
                projectUser.ProjectId = projectId;
                projectUser.ApplicationUserId = userId;
                _repo.Add(projectUser);
            }    
        }

        public void Delete(ProjectUser projectUser)
        {
            _repo.Delete(projectUser);
        }

        public void RemoveUserFromProject(string userId, int projectId)
        {
            if (_repo.UserInProject(userId, projectId))
            {
                _repo.Delete(userId, projectId);
            }
        }
        public List<ProjectUser> GetAll()
        {
            return _repo.GetAll();
        }
    }
}