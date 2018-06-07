using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProject.Controllers
{
    public class RegistrationController : Controller
    {

        public class NUser
        {
            internal bool IsAdministrator { get; set; }

            public int UserId { get; set; }
            public string Username { get; set; }
            public bool Password { get; set; }
        }

        public class NUserRepository
        {
            public NUser GetUserByNameAndPassword(string Username, string Password)
            {
                return new NUser()
                {
                    IsAdministrator = false
                };
            }

            internal object GetUsers()
            {
                throw new NotImplementedException();
            }
        }
    }
}
