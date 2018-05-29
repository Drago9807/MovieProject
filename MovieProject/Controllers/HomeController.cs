using MovieProject.Helpers;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPost(LoginFormModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
         //<<<<<<<<<<<<
        public class Newcomer
        {
            public int ID { get; set; }
            public string Username { get; set; }
            public bool IsAdministrator { get; set; }
        }
        public class NewcomerRepository
        {
            public Newcomer GetUserByNameAndPassword(string username, string password)
            {
                return new Newcomer()
                {
                    ID = 2,
                    Username = username,
                    IsAdministrator = true
                };
            }
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPostntnt(LoginFormModel viewModel)
        {
            if (ModelState.IsValid)
            {
                #region mockup classes
                // here we have to check if the username exists in the database
                NewcomerRepository newcomerRepository = new NewcomerRepository();
                Newcomer dbUser = newcomerRepository.GetUserByNameAndPassword(viewModel.Username, viewModel.Password);

                bool isUserExists = dbUser != null;
                if (isUserExists)
                {
                    UserLoginProcess.Current.SetCurrentUser(dbUser.ID, dbUser.Username, dbUser.IsAdministrator);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
                #endregion
            }
            // if we are here, this means there is some validation error and we have to show the login screen again
            return View();
        }

        public ActionResult Logout()
        {
            UserLoginProcess.Current.Logout();
            return RedirectToAction("Index");
        }


    }
}