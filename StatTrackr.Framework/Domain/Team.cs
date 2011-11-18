using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using StatTrackr.Framework.Domain.Base;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace StatTrackr.Framework.Domain
{
    [DataContract]
    public class Team 
    {
        [DataMember]
        [Key]
        public int TeamID { get; set; }
        [DataMember]
        [StringLength(50)]
        public string TeamName { get; set; }
        [DataMember]
        [StringLength(255)]
        public string PhotoUrl { get; set; }
        
        public virtual League League { get; set; }
        
        public virtual ICollection<Player> Players { get; set; }
        
        public virtual User Owner { get; set; }

        [DataMember]
        public DateTime? DateCreated { get; set; }
        [DataMember]
        public DateTime? DateMotified { get; set; }
        


        //public static Team GetById(int teamId)
        //{
        //    return Team.FindByPrimaryKey(teamId);
        //}
        //public static List<Team> GetAllByLeagueId(int leagueId){
        //    League tempLeague = League.getById(leagueId);
        //    return Team.FindAllByProperty("league", tempLeague).ToList();
        //}

        //public void remove()
        //{
        //    throw new NotImplementedException();
        //}
    }

}
