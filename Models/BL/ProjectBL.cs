using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.BL
{
    public class ProjectBL
    {
        private ProjectRepo _repo;

        public ProjectBL(ProjectRepo repo)
        {
            _repo = repo;
        }

        public Project GetProject(int Id)
        {
            return _repo.Get(Id);
        }

        public IList<Project> GetAllProjects()
        {
            return _repo.Get();
        }

        public void CreateAProject(string name)
        {
            _repo.Create(name);
        }

        public void EditAProject(string name)
        {
            _repo.Edit(name);
        }


    }
}