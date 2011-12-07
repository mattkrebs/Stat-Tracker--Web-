using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StatTrackr.Framework.Domain;
using System.Web.Mvc;

namespace StatTrackr.Web.Models
{
    public class TeamModel
    {
        public int TeamID { get; set; }
        public String TeamName { get; set; }
        public String PhotoUrl { get; set; }
       
        public int LeagueId { get; set; }



        public TeamModel(Team team)
        {
            if (team.TeamName != null)
                this.TeamID = team.TeamID;

            this.TeamName = team.TeamName;
            this.PhotoUrl = team.PhotoUrl;

            if(team.League != null)
                this.LeagueId = team.League.LeagueID;
        }

        public TeamModel() { }
    }
}