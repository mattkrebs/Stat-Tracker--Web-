using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework;

namespace StatTrackr.Web.Models
{
    public class StatHelper
    {
        public static List<League> GetAllLeagues()
        {
            List<League> leagues = new List<League>();
            using (var db = new StatContext())
            {
                foreach (var item in db.Leagues.ToList())
                {
                    if (item.Division != null)
                     item.Name = String.Format("{0}  ({1})",item.Name, item.Division.Name);
                   
                   
                    leagues.Add(item);
                }
            }
            return leagues;
        }
        public static List<Division> GetAllDivisions()
        {
            List<Division> divisions = new List<Division>();
            using (var db = new StatContext())
            {
                foreach (var item in db.Divisions.ToList())
                {
                    
                    divisions.Add(item);
                }
            }
            return divisions;
        }


    }
}