using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Web.Models;
using StatTrackr.Framework;
using StatTrackr.Framework.Domain;
using StatTrackr.Core;
using StatTrackr.Framework.Security;
using Newtonsoft.Json;
using StatTrackr.Framework.Service;

namespace StatTrackr.Web.Controllers
{

   
    [Authorize(Roles="Administrator")]
    public class TeamController : Controller
    {


        Guid OwnerId = UserService.GetOwner(CodeFirstSecurity.CurrentUserId).UserID;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            Navigation nav = Navigation.GetByCurrentUser();

            ViewBag.Title = "Admin Home";
            ViewBag.selectedPage = "";
            ViewBag.NavigationItems = nav;
            base.Initialize(requestContext);
        }


        public ActionResult Index()
        {

            List<Team> teams = new List<Team>();
            using (StatContext ctx = new StatContext())
            {
                teams = ctx.Teams.Include("League").Where(x => x.Owner.UserID == OwnerId).ToList();
            }
            return View(teams);
        }
          

        public ActionResult Create()
        {
            return View("Create", new TeamModel());
        }
        [HttpPost]
        public ActionResult Create(TeamModel mTeam)
        {
            if (ModelState.IsValid)
            {
                using (StatContext ctx = new StatContext())
                {
                    Team team = new Team()
                    {
                        TeamName = mTeam.TeamName,
                        PhotoUrl = mTeam.PhotoUrl,
                        DateCreated = DateTime.Now,
                        DateMotified = DateTime.Now,
                        Owner = ctx.Users.Find(OwnerId),
                        League = ctx.Leagues.Where(x => x.LeagueID == mTeam.LeagueId && x.Owner.UserID == OwnerId).FirstOrDefault()
                    };
                    ctx.Entry(team).State = System.Data.EntityState.Added;
                    ctx.SaveChanges();
                }
            }

            return RedirectToAction("Index","League");
        }
       

        public ActionResult Edit(int id)
        {
            TeamModel tModel;
            using (StatContext ctx = new StatContext())
            {
                Team team = ctx.Teams.Where(x => x.TeamID == id && x.Owner.UserID == OwnerId).FirstOrDefault();
                tModel = new TeamModel(team);
            }
            

            return View(tModel);
        }

        [HttpPost]
        public ActionResult Edit(TeamModel tModel)
        {

            using (StatContext context = new StatContext())
            {
                Team team = context.Teams.Where(x => x.TeamID == tModel.TeamID && x.Owner.UserID == OwnerId).FirstOrDefault();
                team.TeamName = tModel.TeamName;
                team.PhotoUrl = tModel.PhotoUrl;
                team.League = context.Leagues.Find(tModel.LeagueId);

                context.Entry(team).State = System.Data.EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("Index", "Team");
        }
   

    }
}
