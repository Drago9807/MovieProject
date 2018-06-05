using MovieProject.Helpers;
using MovieProject.Models;
using MovieProjectDB;
using MovieProjectDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MovieProject.Controllers.LoginController;

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
        //ottuk pochva registration formata
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }     
        [HttpPost]
        public ActionResult Registration(RegistrationFormModel viewModel)
        {
            // server validation for Firstname to be with capital letter
            if (string.IsNullOrEmpty(viewModel.FirstName) == false)
            {
                char firstLetter = viewModel.FirstName[0];
                if (char.IsUpper(firstLetter) == false)
                {
                    ModelState.AddModelError("FirstName", "First name should start with a capital letter!");
                }
            }

            // Do not save to database when the ModelState is not valid !
            if (ModelState.IsValid)
            {
                // save the information to the database
                // ...
                TempData["Message"] = "Registration successful!";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //ottuk pochva login formata
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }       
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login(LoginFormModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                   //User user = uow.UserRepository.Login(username, password)
                    return View();
                }
                catch
                {
                    ModelState.AddModelError("", "Details are invalid!");
                }
                
            }
            return RedirectToAction("Index");           
        }
        //UserRepository
        
        public ActionResult LoginPost(LoginFormModel viewModel)
        {
            if (ModelState.IsValid)
            {                               
                UserRepository userRepository = new UserRepository();
                LoginController.NUser dbUser = userRepository.GetUserByNameAndPassword(viewModel.Username, viewModel.Password);

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
            }
            return View();
        }

        public ActionResult Logout()
        {
            UserLoginProcess.Current.Logout();
            return RedirectToAction("Index");
        }
    }
}