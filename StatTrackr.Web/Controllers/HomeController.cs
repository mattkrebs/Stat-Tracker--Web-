using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Core;

namespace StatTrackr.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            //This is to initallize the DB if it is not created
            TeamService serv = new TeamService();

            serv.GetAll();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
