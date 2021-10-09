using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AssignmentOne.Models;

namespace AssignmentOne.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if(ModelState.IsValid) {
                var found = Repository.Users.Where(u => u.Email.ToLower().Equals(user.Email.ToLower()));

                // turn found user into list and if there is a user return the view 
                if(found.ToList().Count() > 0) 
                {
                    ViewBag.UserFound = true;
                    return View();
                } 
                else 
                {
                    Repository.AddUser(user);
                    return View("Login");
                }
            } 
            else 
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel user) 
        {
             if(ModelState.IsValid) {
                var found = Repository.Users.Where(u => u.Email.ToLower().Equals(user.Email.ToLower()) && u.Password.Equals(user.Password)).FirstOrDefault();

                // turn found user into list and if there is a user return the view 
                if(found == null) 
                {
                    ViewBag.UserFound = false;
                    return View();
                } 
                else 
                {
                    found.IsLoggedIn = true;
                    return RedirectToAction("Dashboard", found);
                }
            } 
            else 
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Dashboard(User user) 
        {
            ViewBag.User = user;
            if(user.IsLoggedIn) {
                TempData["userEmail"] = user.Email;
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult UserListing() 
        {   
           
            if(TempData["userEmail"] == null) {
                return RedirectToAction("Login");
            } else {
                ViewBag.User = Repository.Users.Where(u => u.Email == TempData["userEmail"].ToString()).First();
                ViewBag.Users = Repository.Users;
                return View();
            }
        }

        [HttpGet]
        public IActionResult SignOut(string email) {
            TempData["userEmail"] = null;
            Repository.Users.Where(u => u.Email == email).First().IsLoggedIn = false;
            return RedirectToAction("Login");
        }
    }
}
