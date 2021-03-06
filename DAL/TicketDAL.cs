﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BugTrackerApp.Models;

namespace BugTrackerApp.DAL
{
    public class TicketDAL 
    {
        ApplicationDbContext db = new ApplicationDbContext();
        
        public void Add(Ticket ticket)
        {
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }

        public Ticket Get(int Id)
        {
            return db.Tickets.Find(Id);
        }

        public void Edit(Ticket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IList<Ticket> Get()
        {
            return db.Tickets.ToList();
        }

        public List<Ticket> GetOwnedTicktsForUser(string id)
        {
            return db.Tickets.Where(t => t.OwnerUserId == id).ToList();
        }
    }
}