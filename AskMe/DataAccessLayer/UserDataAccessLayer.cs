using AskMe.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AskMe.DataAccessLayer
{
    public class UserDataAccessLayer
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}