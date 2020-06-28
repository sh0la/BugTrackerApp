using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.DAL
{
    public class ProjectRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Project Get(int Id)
        {
            return db.Projects.Find(Id);
        }

        public IList<Project> Get()
        {
            return db.Projects.ToList();
        }

        public void Add(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
        }

        public void Edit(Project project)
        {
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}