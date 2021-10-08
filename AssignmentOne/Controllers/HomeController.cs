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
        public IActionResult Index(User user)
        {
            return View();
        }
    }
}
