using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProject.Controllers
{
    public class LoginController : Controller
    {

        public class NUser
        {
            public int ID { get; set; }
            public string Username { get; set; }
            public bool IsAdministrator { get; set; }
        }
        public class UserRepository
        {
            public NUser GetUserByNameAndPassword(string username, string password)
            {
                return new NUser()
                {
                    ID = 2,
                    Username = username,
                    IsAdministrator = true
                };
            }
        }
    }
}
