using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Helpers
{
    public class UserLoginProcess
    {
        public int UserID { get; private set; }
        public string Username { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public bool IsAdministrator { get; private set; }

        private UserLoginProcess()
        {
            //IsAuthenticated = false;  
        }

        public static UserLoginProcess Current
        {
            get
            {
                UserLoginProcess UserLoginProcess = (UserLoginProcess)HttpContext.Current.Session["LoginUser"];
                if (UserLoginProcess == null)
                {
                    UserLoginProcess = new UserLoginProcess();
                    HttpContext.Current.Session["LoginUser"] = UserLoginProcess;
                }
                return UserLoginProcess;
            }
        }

        public void SetCurrentUser(int userID, string username, bool isAdministrator)
        {
            this.IsAuthenticated = true;
            this.IsAdministrator = isAdministrator;
            this.UserID = userID;
            this.Username = username;
        }

        public void Logout()
        {
            this.IsAuthenticated = false;
            this.IsAdministrator = false;
            this.UserID = 0;
            this.Username = string.Empty;
        }

    }
}