using ClassRegistrationSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClassRegistrationSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Student");
        }
    }
}