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

namespace BugTrackerApp.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private UserBL _userBL;
        private UserDAL _userRepo;
        private ProjectUserBL _puBL;
        private ProjectUserRepo _puRepo;
        private ProjectRepo _pRepo;
        private ProjectBL _pBL;

        public ApplicationUsersController()
        {
            _puRepo = new ProjectUserRepo();
            _puBL = new ProjectUserBL(_puRepo);
            _userRepo = new UserDAL();
            _userBL = new UserBL(_userRepo, _puBL);
            _pRepo = new ProjectRepo();
            _pBL = new ProjectBL(_pRepo);
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
            pmDashboard.Projects = db.Projects;

            var tickets = db.Tickets.ToList();
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserId);
            return View(pmDashboard);
        }

        [HttpGet]
        public ActionResult AddUserToProject()
        {
            var projectUser = new ProjectUserViewModel ();
            projectUser.Users = db.Users;
            projectUser.Projects = db.Projects;
            ViewBag.UserId = new SelectList(projectUser.Users, "Id", "UserName");
            ViewBag.ProjectId = new SelectList(projectUser.Projects, "Id", "Name");

            return View(projectUser);
        }

        [HttpPost]
        public ActionResult AddUserToProject(string userId, int projectId, ProjectUserViewModel projectUser)
        {
            //var projectUser = new ProjectUserViewModel { };
            //projectUser.Users = db.Users;
            //projectUser.Projects = db.Projects;
            ViewBag.UserId = new SelectList(_userBL.GetAllUsers(), "Id", "UserName");
            ViewBag.ProjectId = new SelectList(_pBL.GetAllProjects(), "Id", "Name");


            _userBL.AddAProjectManagerToAProject(projectId, userId);
            return View(projectUser);
        }
        
        //public ActionResult AddDeveloperToTicket(Ticket ticket, string userId)
        //{
        //    ticket.AssignedToUserId = userId;
        //    return View();
        //}

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
            //ViewBag.OwnerUserId = new SelectList(db.Users, "Id", "Email", ticket.OwnerUserId);
            //ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", ticket.ProjectId);
            //ViewBag.TicketStatusId = new SelectList(db.TicketStatuses, "Id", "Name", ticket.TicketStatusId);
            //ViewBag.TicketTypeId = new SelectList(db.TicketTypes, "Id", "Name", ticket.TicketTypeId);
            //ViewBag.TicketPriorityId = new SelectList(db.TicketPriorities, "Id", "Name", ticket.TicketPriorityId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
            //ViewBag.OwnerUserId = new SelectList(db.Users, "Id", "Email", ticket.OwnerUserId);
            //ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", ticket.ProjectId);
            //ViewBag.TicketStatusId = new SelectList(db.TicketStatuses, "Id", "Name", ticket.TicketStatusId);
            //ViewBag.TicketTypeId = new SelectList(db.TicketTypes, "Id", "Name", ticket.TicketTypeId);
            //ViewBag.TicketPriorityId = new SelectList(db.TicketPriorities, "Id", "Name", ticket.TicketPriorityId);
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
    }
}
