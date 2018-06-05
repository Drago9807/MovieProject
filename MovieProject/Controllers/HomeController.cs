using MovieProject.Helpers;
using MovieProject.Models;
using MovieProjectDB;
using MovieProjectDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MovieProject.Controllers.RegistrationController;

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
            if (ModelState.IsValid)
            {
                MovieProjectDB.Entities.User user = new MovieProjectDB.Entities.User()
                {
                    UserId = viewModel.UserId,
                    UserName = viewModel.Username,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Password = viewModel.Password,
                    Email = viewModel.Email,
                    PhoneNumber = viewModel.PhoneNumber
                };
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
        
        public ActionResult LoginPost(LoginFormModel viewModel)
        {
            if (ModelState.IsValid)
            {                               
                UserRepository userRepository = new UserRepository();
                RegistrationController.NUser dbUser = userRepository.GetUserByNameAndPassword(viewModel.Username, viewModel.Password);

                bool isUserExists = dbUser != null;
                if (isUserExists)
                {
                    UserLoginProcess.Current.SetCurrentUser(dbUser.UserId, dbUser.Username, dbUser.Password);
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