using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTrackerApp.Models
{
    public class UserBL
    {
        UserDAL _repo;

        public UserBL(UserDAL repo)
        {
            _repo = repo;
        }

       




    }
}