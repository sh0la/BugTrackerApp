﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
{
    public class PMDashboardViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public string ApplicationUserId { get; set; }
    }
}