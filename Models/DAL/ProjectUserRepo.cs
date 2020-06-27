using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models.DAL
{
    public class ProjectUserRepo
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ProjectUser Get(int id)
        {
            return db.ProjectUsers.Find(id);
           
        }

        public void Add(ProjectUser projectUser)
        {
            db.ProjectUsers.Add(projectUser);
            db.SaveChanges();
        }

        public List<ProjectUser> GetAll()
        {
            return db.ProjectUsers.ToList();
        }
    }
}