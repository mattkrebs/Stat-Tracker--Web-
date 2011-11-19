using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Core;
using StatTrackr.Framework.Domain;
using Newtonsoft.Json;

namespace StatTrackr.Web.Controllers
{
    public class ApiController : Controller
    {

        // POST: /Account/Register
        [HttpPost]
        public string Authenticate(string username, string password, string apikey)
        {
            return UserService.Login(username, password, apikey);
        }


        [HttpPost]
        public string AddTeam(Team team, string token)
        {
            User owner = UserService.GetOwner(token);
            TeamService ts = new TeamService();
            if (owner == null)
                return "Not Logged In";

            ts.Create(team, owner.UserID);
            return "success";
        }

        [HttpPost]
        public string UpdateTeam(Team team, string token)
        {
            User owner = UserService.GetOwner(token);
            TeamService ts = new TeamService();
            if (owner == null)
                return "Not Logged In";

            ts.Update(team, owner.UserID);
            return "success";
        }

        [HttpPost]
        public string TeamList(string token)
        {

            var model = new TeamService().GetAll(UserService.GetOwner(token).UserID);
            return JsonConvert.SerializeObject(model);
        }

    }
}
