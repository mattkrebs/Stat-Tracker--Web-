using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StatTrackr.Core;
using StatTrackr.Framework.Domain;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;

namespace StatTrackr.Web.Controllers
{
    public class ApiController : Controller
    {

        // POST: /Account/Register
        [HttpPost]
        public JsonResult Authenticate(string username, string password, string apikey)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            response.Add("token", UserService.Login(username, password, apikey));
            return Json(response);
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

        [HttpPost]
        public string SyncTeams(List<Team> teams, string token)
        {
            Guid ownerid = new Guid();
            try
            {
                ownerid = ValidateToken(token);
                TeamService db = new TeamService();
                //     var model = new TeamService().GetAll(UserService.GetOwner(token).UserID);
                if (teams != null)
                {
                    return TeamList(token);
                }
                foreach (var team in teams)
                {
                    //no - add to 'clean' teams
                    Team cleanTeam = db.GetById(team.TeamID, ownerid);
                    // check to see if team exists
                    if (cleanTeam != null)
                    {
                        // yes - check to see if 'dirty' team updatetimestamp is > then 'clean' team updatetimestamp
                        if (team.DateMotified > cleanTeam.DateMotified)
                        {
                            // yes - update
                            db.Update(team, ownerid);
                        }
                        // no - ignore and leave alone
                    }
                    //no - add to 'clean' teams
                    else
                    {
                        db.Create(team, ownerid);
                    }
                }
               
            }catch (SqlException ex){
                return HandleException(ex, ErrorType.SqlException);
            }catch (NullReferenceException ex){
                return HandleException(ex, ErrorType.NullReferance);
            }
             return JsonConvert.SerializeObject(new TeamService().GetAll(ownerid));

        }

        private string HandleException(Exception ex, ErrorType type)
        {
            
            Dictionary<String, String> exception = new Dictionary<string, string>();
            switch (type)
            {
                case ErrorType.NullReferance:
                    exception.Add("errorCode", "Null Referance");
                    break;
                case ErrorType.Exception:
                    exception.Add("errorCode", "Generic Exception");
                    break;
                case ErrorType.SqlException:
                    exception.Add("errorCode", "Sql Exception");
                    break;
                default:
                    break;
            }
            
            exception.Add("errorText", ex.ToString());
            return JsonConvert.SerializeObject(exception);
        }

        private Guid ValidateToken(string token)
        {
            Guid ownerid = UserService.GetOwner(token).UserID;
            if (ownerid == null)
                throw new NullReferenceException();

                return ownerid;
        }

        enum ErrorType
        {
            NullReferance,
            SqlException,
            Exception
        }

    }
}
