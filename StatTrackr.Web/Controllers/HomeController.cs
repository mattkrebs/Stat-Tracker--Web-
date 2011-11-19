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
            ViewBag.Title = "Home Page";
            ViewBag.selectedPage = "home";

            //TeamService serv = new TeamService();

            //serv.GetAll();

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            ViewBag.selectedPage = "login";

            return View();
        }


        public ActionResult About()
        {
            return View();
        }
    }
}
