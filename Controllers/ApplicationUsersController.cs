using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTrackerApp.Models;
using BugTrackerApp.Models.BL;
using Microsoft.AspNet.Identity;
using Microsoft.VisualBasic.ApplicationServices;
using BugTrackerApp.Models.DAL;
using BugTrackerApp.Models.VM;

namespace BugTrackerApp.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private UserBL _userBL;
        private ProjectUserBL _puBL;
        private ProjectBL _pBL;
        private TicketBL _tBL;

        public ApplicationUsersController()
        {
            _puBL = new ProjectUserBL();
            _userBL = new UserBL();
            _pBL = new ProjectBL();
            _tBL = new TicketBL();
        }

        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DashboardTemp()
        {
            var pmDashboard = new PMDashboardViewModel { };
            pmDashboard.ApplicationUserId = User.Identity.GetUserId();
            pmDashboard.Projects = _pBL.GetAllProjects().ToList();

            var tickets = _tBL.GetAllTickets().ToList();
            var currentUserId = User.Identity.GetUserId();
            var currentUser = _userBL.GetAUser(currentUserId);
            return View(pmDashboard);
        }

        [HttpGet]
        public ActionResult AddUserToProject()
        {
            var projectUser = new ProjectUserViewModel ();
            projectUser.Users = _userBL.GetAllUsers().ToList();
            projectUser.Projects = db.Projects;
            ViewBag.UserId = new SelectList(projectUser.Users, "Id", "UserName");
            ViewBag.ProjectId = new SelectList(projectUser.Projects, "Id", "Name");

            return View(projectUser);
        }

        [HttpPost]
        public ActionResult AddUserToProject(string userId, int projectId, ProjectUserViewModel projectUser)
        {
            ViewBag.UserId = new SelectList(_userBL.GetAllUsers(), "Id", "UserName");
            ViewBag.ProjectId = new SelectList(_pBL.GetAllProjects(), "Id", "Name");


            _userBL.AddAProjectManagerToAProject(projectId, userId);
            return View(projectUser);
        }
        
        // GET: Tickets/Edit/5
        public ActionResult AddDeveloperToTicket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            ViewBag.AssignedToUserId = new SelectList(db.Users, "Id", "Email", ticket.AssignedToUserId);
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDeveloperToTicket([Bind(Include = "Id,Title,Description,Created,Updated,ProjectId,TicketTypeId,TicketPriorityId,TicketStatusId,OwnerUserId,AssignedToUserId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignedToUserId = new SelectList(db.Users, "Id", "Email", ticket.AssignedToUserId);

            return View(ticket);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult UserRoles()
        {
            UserRolesVM viewModel = new UserRolesVM();
            viewModel.Admins = _userBL.GetAllUsersInRole("Administrator");
            viewModel.PMs = _userBL.GetAllUsersInRole("Project Manager");
            viewModel.Devs = _userBL.GetAllUsersInRole("Developer");
            viewModel.Submitters = _userBL.GetAllUsersInRole("Submitter");
            return View(viewModel);
        }


        public ActionResult userPermisions(string id)
        {
            ApplicationUser user = _userBL.GetAUser(id);
            userPermisionsVM vm = new userPermisionsVM();
            vm.user = user;
            vm.RolesUserIsIn = _userBL.AllRolesOfAUser(id);
            vm.RolesUserIsNotIn = _userBL.GetRoles().Where(r => !vm.RolesUserIsIn.Contains(r)).ToList();
            return View(vm);
        }

    }
}
