﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Web.Models;
using StatTrackr.Framework;
using StatTrackr.Framework.Domain;
using StatTrackr.Core;
using StatTrackr.Framework.Security;

namespace StatTrackr.Web.Controllers
{
    [Authorize(Roles="Administrator")]
    public class TeamController : Controller
    {
        //
        // GET: /Team/
        StatContext ctx = new StatContext();
        TeamService service = new TeamService();
        
        public ActionResult Index(int id)
        {
            Team team = ctx.Teams.Where(x => x.TeamID == id).FirstOrDefault();
            return PartialView(team);
        }
        public ActionResult List(int id)
        {
            List<Team> teams = service.GetAllByLeagueId(id);
            return PartialView("List", teams);
        }

        public ActionResult QuickView(int id)
        {
            return PartialView("QuickView", service.GetById(id));
        }

        public ActionResult Create()
        {
            return View("Create", new Team());
        }

        public ActionResult CreatePartial(int id)
        {
            League league = ctx.Leagues.Find(id);
         
            return PartialView("_TeamCreatePartial",new TeamModel {LeagueId = league.LeagueID });
        }

        [HttpPost]
        public ActionResult Create(TeamModel team)
        {
            if (ModelState.IsValid)
            {
                service.Create(new Team() { TeamName = team.TeamName, PhotoUrl = team.PhotoUrl }, UserService.GetOwner(CodeFirstSecurity.CurrentUserId).UserID);
               
            }

            return RedirectToAction("Index","League");
        }

        public ActionResult Add(int id)
        {
            League league = ctx.Leagues.Find(id);
            ViewBag.LeagueID = league.LeagueID;
            TeamLeagueModel tm = new TeamLeagueModel();

            tm.CurrentTeams = league.Teams.ToList();
            tm.AvailableTeams = new List<Team>();
            foreach (Team ateam in ctx.Teams)
            {
                bool check = (from t in league.Teams
                         select t.TeamID).Contains(ateam.TeamID);
                if (!check)
                    tm.AvailableTeams.Add(ateam);
            }

            return PartialView("AddTeamToLeague", tm);
        }
        [HttpPost]
        public ActionResult Add(int[] addIds, int[] removeIds, int leagueid)
        {
            League league = ctx.Leagues.Find(leagueid);
            foreach (var rId in removeIds)
            {
                Team team = ctx.Teams.Find(rId);
                team.League = null;
                ctx.Entry(team).State = System.Data.EntityState.Modified;
                ctx.SaveChanges();
            }
            foreach (var id in addIds)
            {
                Team team = ctx.Teams.Find(id);
                team.League = league;
                ctx.Entry(team).State = System.Data.EntityState.Modified;
                ctx.SaveChanges();
            }
            return View("Index", "League");
        }


        public ActionResult Edit(int id)
        {
            Team team = ctx.Teams.Find(id);
           
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {

            if (ModelState.IsValid)
            {
                ctx.Entry(team).State = System.Data.EntityState.Modified;
                ctx.SaveChanges();
            }
            return RedirectToAction("Index", "League");
        }
        public ActionResult CreateLeaguePartial()
        {
            return PartialView("_LeagueCreatePartial");
        }
        [HttpPost]
        public ActionResult CreateLeague(League league)
        {
            if (ModelState.IsValid)
            {
                ctx.Leagues.Add(league);
                ctx.SaveChanges();
            }
            return RedirectToAction("Create", "Team");
        }

        public ActionResult CreatePlayer(int teamid)
        {
            Player player = new Player();
            player.Teams.Add(ctx.Teams.Find(teamid));
            return PartialView("_PlayerCreatePartial", player);
        }

    }
}
