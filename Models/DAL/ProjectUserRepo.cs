﻿using System;
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
    }
}