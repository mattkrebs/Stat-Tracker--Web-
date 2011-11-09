using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StatTrackr.Framework.Domain;

namespace StatTrackr.Web.Models
{
    public class TeamLeagueModel
    {
        public List<Team> CurrentTeams { get; set; }
        public List<Team> AvailableTeams { get; set; }
    }
}