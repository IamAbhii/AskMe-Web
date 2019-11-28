using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AskMe.DataAccessLayer;
using AskMe.Models;

namespace AskMe.BusinessLayer
{
    public class UserBusinessLayer
    {
        UserDataAccessLayer UserData = new UserDataAccessLayer();

        public List<User> GetUsers()
        {
            return UserData.GetUsers();
        }
    }
}