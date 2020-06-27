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

namespace BugTrackerApp.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private TicketBL _tRepo;
        private ProjectBL _pRepo;
        private TicketPriorityBL _tpRepo;
        private TicketStatusBL _tsRepo;
        private TicketTypeBL _ttRepo;
        private UserBL _uBL;

        public TicketsController()
        {
            _tRepo = new TicketBL();
            _pRepo = new ProjectBL();
            _tpRepo = new TicketPriorityBL();
            _tsRepo = new TicketStatusBL();
            _ttRepo = new TicketTypeBL();
            _uBL = new UserBL();
        }

        public TicketsController(TicketBL repo)
        {
            _tRepo = repo;
        }

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = _tRepo.GetAllTickets();
            return View(tickets);
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = _tRepo.GetTicket((int)id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.OwnerUserId = User.Identity.GetUserId();
            ViewBag.ProjectId = new SelectList(_pRepo.GetAllProjects(), "Id", "Name");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Created,Updated,ProjectId,TicketTypeId,TicketPriorityId,TicketStatusId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.OwnerUserId = User.Identity.GetUserId();
                _tRepo.AddTicket(ticket);
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(_tRepo.GetAllTickets(), "Id", "Name", ticket.ProjectId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = _tRepo.GetTicket((int)id);
            
            ViewBag.AssignedToUserId = new SelectList(_uBL.GetAllUsers(), "Id", "Email", ticket.AssignedToUserId);
            ViewBag.OwnerUserId = new SelectList(_uBL.GetAllUsers(), "Id", "Email", ticket.OwnerUserId);
            ViewBag.ProjectId = new SelectList(_pRepo.GetAllProjects(), "Id", "Name", ticket.ProjectId);
            ViewBag.TicketStatusId = new SelectList(_tsRepo.GetAll(), "Id", "Name", ticket.TicketStatusId);
            ViewBag.TicketTypeId = new SelectList(_ttRepo.GetAllTicketTypes(), "Id", "Name", ticket.TicketTypeId);
            ViewBag.TicketPriorityId = new SelectList(_tpRepo.GetTicketPriorities(), "Id", "Name", ticket.TicketPriorityId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Created,Updated,ProjectId,TicketTypeId,TicketPriorityId,TicketStatusId,OwnerUserId,AssignedToUserId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignedToUserId = new SelectList(_uBL.GetAllUsers(), "Id", "Email", ticket.AssignedToUserId);
            ViewBag.OwnerUserId = new SelectList(_uBL.GetAllUsers(), "Id", "Email", ticket.OwnerUserId);
            ViewBag.ProjectId = new SelectList(_pRepo.GetAllProjects(), "Id", "Name", ticket.ProjectId);
            ViewBag.TicketStatusId = new SelectList(_tsRepo.GetAll(), "Id", "Name", ticket.TicketStatusId);
            ViewBag.TicketTypeId = new SelectList(_ttRepo.GetAllTicketTypes(), "Id", "Name", ticket.TicketTypeId);
            ViewBag.TicketPriorityId = new SelectList(_tpRepo.GetTicketPriorities(), "Id", "Name", ticket.TicketPriorityId);
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
