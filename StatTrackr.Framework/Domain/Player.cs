using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StatTrackr.Framework.Domain.Base;

using System.Runtime.Serialization;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace StatTrackr.Framework.Domain
{
    [DataContract]
    public class Player 
    {

        [DataMember]
        [Key]
        public int PlayerID { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Experiance { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Position { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Weight { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Height { get; set; }
        [DataMember]
        [StringLength(50)]
        public string TwitterHandle { get; set; }
        [DataMember]
        [StringLength(50)]
        public string FavoriteTeam { get; set; }
        [DataMember]
        public string PhotoUrl { get; set; }
      
        public virtual User Owner { get; set; }

        [DataMember]
        public DateTime? DateCreated { get; set; }
        [DataMember]
        public DateTime? DateMotified { get; set; }

        //public static List<Player> GetAllPlayers()
        //{
        //    return Player.FindAll().ToList();
        //}

        //public static Player GetById(int id)
        //{
        //    return Player.FindByPrimaryKey(id);
        //}
   
        //public void remove()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
