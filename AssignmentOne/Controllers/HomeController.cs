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

        public IActionResult Login() 
        {
            return View();
        }
    }
}
