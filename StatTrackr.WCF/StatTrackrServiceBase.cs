using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.WCF.ErrorHandeling;
using System.ServiceModel.Activation;
using StatTrackr.WCF.Interfaces;
using StatTrackr.Core;
using System.Runtime.Serialization.Json;
using StatTrackr.Framework.Domain;
using System.IO;
using System.Web.Script.Serialization;



namespace StatTrackr.WCF
{
    [ServiceErrorBehavior(typeof(ErrorHandler))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class StatTrackrServiceBase : IStatTrackrDomain
    {


        #region IStatTrackrDomain Members

        public string authenticate(string username, string password, string apikey)
        {
            return UserService.Login(username, password, apikey);
        }

       


        public string createteam(string token, Framework.Domain.Team team)
        {
            User owner = UserService.GetOwner(token);
            TeamService ts = new TeamService();
            if (owner == null)
                return "Not Logged In";

            ts.Create(team, owner.UserID);
            return "created";
        }


        public string updateteam(string token, Team team)
        {
            User owner = UserService.GetOwner(token);
            TeamService ts = new TeamService();
            if (owner == null)
                return "Not Logged In";

            ts.Update(team, owner.UserID);
            return "created";
        }

        public string getteams(string token)
        {
            User owner = UserService.GetOwner(token);
            TeamService ts = new TeamService();
            if (owner == null)
                return null;

            JavaScriptSerializer js = new JavaScriptSerializer();

            return js.Serialize(ts.GetAll(owner.UserID));
            
        }

        #endregion
    }
}
