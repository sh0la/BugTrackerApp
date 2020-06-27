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

        public void Delete(string userId, int projectId)
        {
            ProjectUser projectUser = db.ProjectUsers.First(pu => pu.ApplicationUserId == userId && pu.ProjectId == projectId);
            db.ProjectUsers.Remove(projectUser);
            db.SaveChanges();
        }

        public void Delete(ProjectUser projectUser)
        {
            db.ProjectUsers.Remove(projectUser);
            db.SaveChanges();
        }

        public bool UserInProject(string userId, int projectId)
        {
            ProjectUser projectUser = db.ProjectUsers.FirstOrDefault(pu => pu.ApplicationUserId == userId && pu.ProjectId == projectId);
            return !(projectUser == null);
        }
    }
}