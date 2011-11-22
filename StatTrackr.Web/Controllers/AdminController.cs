using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            ViewBag.Title = "Admin Home";
            ViewBag.selectedPage = "admin";

            return View();
        }

    }
}
