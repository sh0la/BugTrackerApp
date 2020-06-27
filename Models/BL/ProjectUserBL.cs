using BugTrackerApp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
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
            var projectUser = new ProjectUser();
            projectUser.ProjectId = projectId;
            projectUser.ApplicationUserId = userId;
            _repo.Add(projectUser);
            
        }


    }
}