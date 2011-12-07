using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StatTrackr.Framework.Domain;
using System.Web.Mvc;
using StatTrackr.Framework;

namespace StatTrackr.Web.Models
{
    public class LeagueModel
    {
        public string Name { get; set; }
        public int LeagueID { get; set; }
        public int DivisionID { get; set; }
       
     
        public LeagueModel(League league) {
            this.Name = league.Name;
            if (league.Name != null)
                this.LeagueID = league.LeagueID;

            if (league.Division != null)
                this.DivisionID = league.Division.DivisionID;
        }
        public LeagueModel() { }


    
    }
}