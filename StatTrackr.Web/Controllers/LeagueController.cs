using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Web.Models;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework;
using StatTrackr.Core;
using StatTrackr.Framework.Security;

namespace StatTrackr.Web.Controllers
{
   [Authorize(Roles = "Administrator")]
    public class LeagueController : Controller
    {
        //All ctx calls should get replaced with Service calls from the StatTrackr.Core.
        StatContext ctx = new StatContext();

        //
        // GET: /League/
        LeagueService league = new LeagueService();

        public ActionResult Index()
        {
            return View(league.GetAll(CodeFirstSecurity.CurrentUserId));
        }
        public ActionResult Edit(int id)
        {
        
            LeagueModel mLeague = new LeagueModel(ctx.Leagues.Find(id));
      
           
            return PartialView("_EditLeague", mLeague);
        }
        [HttpPost]
        public ActionResult Edit(LeagueModel mleague)
        {
            League league = ctx.Leagues.Find(mleague.LeagueID);
            if (ModelState.IsValid)
            {
                league.Division = ctx.Divisions.Find(mleague.DivisionID);
                league.DateMotified = DateTime.Now;
                ctx.Entry(league).State = System.Data.EntityState.Modified;
                ctx.SaveChanges();
            }

            return RedirectToAction("Index","League");
        }
        public ActionResult New()
        {
            return View(new League());
        }
        [HttpPost]
        public ActionResult New(League league)
        {
            if (ModelState.IsValid){
            
                ctx.Leagues.Add(league);
                ctx.SaveChanges();
               
             }
             return RedirectToAction("Index");
        }

        public ActionResult CreateDivision()
        {
            return PartialView("_DivisionCreate");
        }
        [HttpPost]
        public ActionResult CreateDivision(Division division)
        {
            if (ModelState.IsValid)
            {
                ctx.Divisions.Add(division);
                ctx.SaveChanges();
            }
            return RedirectToAction("New","League");
        }
    }
}
