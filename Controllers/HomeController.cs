using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackendCase.Model;

namespace BackendCase.Controllers
{
    public class HomeController : Controller
    {
        BackendConnectionString db  = new BackendConnectionString();


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
       
    }
}
