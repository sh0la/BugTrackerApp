using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTrackerApp.Models;
using BugTrackerApp.BL;
using Microsoft.AspNet.Identity;
using BugTrackerApp.Models.BL;

namespace BugTrackerApp.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ProjectBL _pRepo;
        private ProjectUserBL _puRepo;
        private UserBL _uRepo;

        public ProjectsController()
        {
            _pRepo = new ProjectBL();
            _puRepo = new ProjectUserBL();
            _uRepo = new UserBL();
        }

        // GET: Projects
        public ActionResult Index()
        {
            return View(_pRepo.GetAllProjects());
        }

        public ActionResult Projects(List<Project> projects, string pageTitle)
        {
            ViewBag.Title = pageTitle;
            return View(projects);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _pRepo.GetProject((int)id);
            return View(project);
        }

        [Authorize(Roles = "Adminstrator, Project Manager")]
        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Adminstrator, Project Manager")]
        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Project project)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                _pRepo.Add(project);
                _puRepo.CreateProjectUser(project.Id, userId);
                return RedirectToAction("Index");
            }

            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = "Adminstrator, Project Manager")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _pRepo.GetProject((int)id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Adminstrator, Project Manager")]
        public ActionResult Edit([Bind(Include = "Id,Name")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = "Adminstrator, Project Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Adminstrator, Project Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Adminstrator, Project Manager")]
        public ActionResult OwnedProjects()
        {
            string userId = User.Identity.GetUserId();
            List<Project> userProjects = _uRepo.GetProjectsOfUser(userId);
            return View(userProjects);
        }
    }
}
