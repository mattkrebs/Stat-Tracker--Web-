using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Web.Models;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework;

namespace StatTrackr.Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class PlayerController : Controller
    {
        //
        // GET: /Player/
        StatContext ctx = new StatContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new PlayerModel());
        }

        [HttpPost]
        public ActionResult Create(PlayerModel player)
        {
            if (ModelState.IsValid)
            {
                ctx.Players.Add(player);
                ctx.SaveChanges();
            }
           
           
            return RedirectToAction("Index","Team", new{id=player.CurrentTeamId});
        }
    }
}
