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

        public ProjectUserBL(ProjectUserRepo repo)
        {
            _repo = repo;
        }

        public ProjectUser GetProjectUser(int id)
        {
            return _repo.Get(id);
        } 


    }
}