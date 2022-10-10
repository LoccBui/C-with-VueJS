using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        public User(string user, string pass)
        {
            username = user;
            password = pass;
        }
        public string username = "a";
        public string password = "b";
    }
}