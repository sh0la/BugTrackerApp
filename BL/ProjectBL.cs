using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerApp.Models.DAL;
using BugTrackerApp.Models;

namespace BugTrackerApp.BL
{
    public class ProjectBL
    {
        private ProjectRepo _repo;

        public ProjectBL()
        {
            _repo = new ProjectRepo();
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
            Project project = new Project();
            project.Name = name;
            _repo.Add(project);
         
        }
        
        public void EditAProject(Project project)
        {
            _repo.Edit(project);
        }

        public void Add(Project project)
        {
            _repo.Add(project);
        }


    }
}