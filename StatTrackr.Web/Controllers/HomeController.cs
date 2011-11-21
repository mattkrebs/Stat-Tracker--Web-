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


        public ActionResult About()
        {
            ViewBag.Title = "About Us";
            ViewBag.selectedPage = "about";

            return View();
        }

        public ActionResult Features()
        {
            ViewBag.Title = "Services";
            ViewBag.selectedPage = "features";

            return View();
        }

        public ActionResult Apps()
        {
            ViewBag.Title = "Apps";
            ViewBag.selectedPage = "apps";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            ViewBag.selectedPage = "contact";


            return View();
        }
    }
}
