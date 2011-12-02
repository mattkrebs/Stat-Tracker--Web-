using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using StatTrackr.Framework.Domain.Base;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using StatTrackr.Framework.Security;

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
        //[StringLength(50)]
        //public string Color { get; set; }
        //[StringLength(50)]
        //public string LogoUrl { get; set; }

        public virtual League League { get; set; }
        
        public virtual ICollection<Player> Players { get; set; }
        [ScriptIgnore]
        public virtual User Owner { get; set; }

        [DataMember]
        public DateTime? DateCreated { get; set; }
        [DataMember]
        public DateTime? DateMotified { get; set; }


        public static List<Team> GetAllTeamsByUserId(Guid userId)
        {
            List<Team> teams = new List<Team>();

            using (var ctx = new StatContext())
            {
                var results = from e in ctx.Teams
                              where e.Owner.UserID == userId
                              select e;

                teams = results.ToList<Team>();
            }

            return teams;
        }

        public static List<Team> GetAllTeamsByCurrentUser()
        {
            return GetAllTeamsByUserId(CodeFirstSecurity.CurrentUserId);
        }

    }

}
