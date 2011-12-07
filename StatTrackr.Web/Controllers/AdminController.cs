using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Framework.Service;

namespace StatTrackr.Web.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        

        public ActionResult Index()
        {
            if (!StatTrackr.Framework.Security.CodeFirstSecurity.IsAuthenticated)
            {
                return Redirect("/account/logon");
            }

            Navigation nav = Navigation.GetByCurrentUser();

            ViewBag.Title = "Admin Home";
            ViewBag.selectedPage = "admin";
            ViewBag.NavigationItems = nav;

            return View();
        }

        public ActionResult Stats()
        {
            if (!StatTrackr.Framework.Security.CodeFirstSecurity.IsAuthenticated)
            {
                return Redirect("/account/logon");
            }

            Navigation nav = Navigation.GetByCurrentUser();
            ViewBag.Title = "Stats";
            ViewBag.selectedPage = "stats";

            return View();
        }

        public ActionResult Leagues()
        {
            if (!StatTrackr.Framework.Security.CodeFirstSecurity.IsAuthenticated)
            {
                return Redirect("/account/logon");
            }

            Navigation nav = Navigation.GetByCurrentUser();
            ViewBag.Title = "Leagues";
            ViewBag.selectedPage = "leagues";
            ViewBag.NavigationItems = nav;
            

            return View();
        }


        public ActionResult Teams()
        {
            if (!StatTrackr.Framework.Security.CodeFirstSecurity.IsAuthenticated)
            {
                return Redirect("/account/logon");
            }

            Navigation nav = Navigation.GetByCurrentUser();
            ViewBag.Title = "Teams";
            ViewBag.selectedPage = "teams";

            return View();
        }

        public ActionResult Games()
        {
            if (!StatTrackr.Framework.Security.CodeFirstSecurity.IsAuthenticated)
            {
                return Redirect("/account/logon");
            }

            Navigation nav = Navigation.GetByCurrentUser();
            ViewBag.Title = "Games";
            ViewBag.selectedPage = "games";

            return View();
        }

        public ActionResult Divisions()
        {
            if (!StatTrackr.Framework.Security.CodeFirstSecurity.IsAuthenticated)
            {
                return Redirect("/account/logon");
            }

            Navigation nav = Navigation.GetByCurrentUser();
            ViewBag.Title = "Divisions";
            ViewBag.selectedPage = "divisions";

            return View();
        }

        public ActionResult Players()
        {
            if (!StatTrackr.Framework.Security.CodeFirstSecurity.IsAuthenticated)
            {
                return Redirect("/account/logon");
            }

            Navigation nav = Navigation.GetByCurrentUser();
            ViewBag.Title = "Players";
            ViewBag.selectedPage = "players";

            return View();
        }

    }
}
