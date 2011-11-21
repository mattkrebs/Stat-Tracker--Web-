using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Core;
using StatTrackr.Framework.Domain;
using Newtonsoft.Json;
using System.IO;

namespace StatTrackr.Web.Controllers
{
    public class ApiController : Controller
    {

        // POST: /Account/Register
        [HttpPost]
        public JsonResult Authenticate(string username, string password, string apikey)
        {
            return Json(UserService.Login(username, password, apikey));
        }


        [HttpPost]
        public JsonResult AddTeam(Team team, string token)
        {
            User owner = UserService.GetOwner(token);
            TeamService ts = new TeamService();
            if (owner == null)
                return Json("Not authroized");

            Team myteam = ts.Create(team, owner.UserID);
            return Json(myteam);
        }

        [HttpPost]
        public JsonResult UpdateTeam(Team team, string token)
        {
            User owner = UserService.GetOwner(token);
            TeamService ts = new TeamService();
            if (owner == null)
               return Json("Not Logged In");

            Team myteam = ts.Update(team, owner.UserID);
            return Json(myteam);
        }

        [HttpPost]
        public string TeamList(string token)
        {

            var model = new TeamService().GetAll(UserService.GetOwner(token).UserID);
            return JsonConvert.SerializeObject(model);
        }

       

    }
}
