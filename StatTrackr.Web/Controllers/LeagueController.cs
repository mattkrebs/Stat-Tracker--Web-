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
using StatTrackr.Framework.Service;

namespace StatTrackr.Web.Controllers
{
   [Authorize(Roles = "Administrator")]
    public class LeagueController : Controller
    {
       User Owner = UserService.GetOwner(CodeFirstSecurity.CurrentUserId);

       protected override void Initialize(System.Web.Routing.RequestContext requestContext)
       {
           Navigation nav = Navigation.GetByCurrentUser();

           ViewBag.Title = "Admin Home";
           ViewBag.selectedPage = "admin";
           ViewBag.NavigationItems = nav;
           base.Initialize(requestContext);
       }


       public ActionResult Index()
       {

           List<League> teams = new List<League>();
           using (StatContext ctx = new StatContext())
           {
               teams = ctx.Leagues.Include("Division").Where(x => x.Owner.UserID == Owner.UserID).ToList();
           }
           return View(teams);
       }


       public ActionResult Create()
       {
           return View("Create", new LeagueModel());
       }
       [HttpPost]
       public ActionResult Create(LeagueModel model)
       {
           if (ModelState.IsValid)
           {
               using (StatContext ctx = new StatContext())
               {
                   League league = new League()
                   {
                       Name = model.Name,
                       DateCreated = DateTime.Now,
                       DateMotified = DateTime.Now,
                       Owner = ctx.Users.Find(Owner.UserID),
                       Division = ctx.Divisions.Find(model.DivisionID)
                       
                   };
                   ctx.Entry(league).State = System.Data.EntityState.Added;
                   ctx.SaveChanges();
               }
           }

           return RedirectToAction("Index", "League");
       }

       public ActionResult Edit(int id)
       {
           LeagueModel model;
           using (StatContext ctx = new StatContext())
           {
               League league = ctx.Leagues.Where(x => x.LeagueID == id && x.Owner.UserID == Owner.UserID).FirstOrDefault();
               model = new LeagueModel(league);
           }


           return View(model);
       }

       [HttpPost]
       public ActionResult Edit(LeagueModel model)
       {

           using (StatContext context = new StatContext())
           {
               League league = context.Leagues.Where(x => x.LeagueID == model.LeagueID && x.Owner.UserID == Owner.UserID).FirstOrDefault();
               league.Name = model.Name;
               league.DateMotified = DateTime.Now;
               if (model.DivisionID != null)
               {
                   league.Division = context.Divisions.Find(model.DivisionID);
               }
               context.Entry(league).State = System.Data.EntityState.Modified;
               context.SaveChanges();
           }

           return RedirectToAction("Index", "League");
       }
    }
}
