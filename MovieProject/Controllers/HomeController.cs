using MovieProject.Models;
using MovieProjectDB;
using MovieProjectDB.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
        public ActionResult Index(LoginFormModel model)
        {
           User cbe = new User();
            var s = cbe.User(model.UserName, model.Password);
            

            var item = s.FirstOrDefault();
            if (item == "Success")
            {

                return View("UserLandingView");
            }
            else if (item == "User Does not Exists")
            {
                ViewBag.NotValidUser = item;

            }
            else
            {
                ViewBag.Failedcount = item;
            }

            return View("Index");
        }

        public ActionResult Logout()
        {
            //LoginFormModel.Current.Logout();
            Session.Abandon();
            return RedirectToAction("Index");
        }
       
    }
}