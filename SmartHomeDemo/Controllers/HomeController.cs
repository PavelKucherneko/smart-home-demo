using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHomeDemo.Models;

namespace SmartHomeDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int id=1)
        {
            ViewBag.Title = "SmartHomeDemo home Page";

            if(id < 0)
            {
                return new HttpNotFoundResult("User id is not correct.");
            }
            return View(new HomeViewModel(id));
        }
    }
}
