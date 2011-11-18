using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using StatTrackr.Framework.Domain.Base;
using System.ComponentModel.DataAnnotations;

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
    }
}
