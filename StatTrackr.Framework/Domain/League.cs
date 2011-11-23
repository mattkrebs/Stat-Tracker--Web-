using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using StatTrackr.Framework.Domain.Base;
using System.ComponentModel.DataAnnotations;
using StatTrackr.Framework.Security;

namespace StatTrackr.Framework.Domain
{
    [DataContract]
    public class League 
    {
        [DataMember]
        [Key]
        public int LeagueID { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }
        [DataMember]
        public virtual Division Division { get; set; }
        [DataMember]
        public virtual ICollection<Team> Teams { get; set; }
        [DataMember]
        public virtual Region Region { get; set; }
        [DataMember]
        public virtual User Owner { get; set; }
        [DataMember]
        public DateTime? DateCreated { get; set; }
        [DataMember]
        public DateTime? DateMotified { get; set; }



        //public static League getById(int id)
        //{
        //    return League.FindByPrimaryKey(id);
        //}


        //public static List<League> getAll()
        //{
        //    return League.FindAll().ToList();
        //}

        

        //public void remove()
        //{
        //    throw new NotImplementedException();
        //}

        public static List<League> GetAllLeaguesByUserId(Guid userId)
        {
            List<League> leagues = new List<League>();

            using (var ctx = new StatContext())
            {
                var results = from e in ctx.Leagues
                              where e.Owner.UserID == userId
                              select e;

                leagues = results.ToList<League>();
            }

            return leagues;
        }

        public static List<League> GetAllLeaguesByCurrentUser()
        {
            return GetAllLeaguesByUserId(CodeFirstSecurity.CurrentUserId);
        }
    }
}
