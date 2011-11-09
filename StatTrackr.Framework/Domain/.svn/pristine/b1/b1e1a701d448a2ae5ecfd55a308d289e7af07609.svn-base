using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.Entity;
using StatTrackr.Framework.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace StatTrackr.Framework.Domain
{

    public class Division : DomainBase
    {
        [DataMember]
        [Key]
        public int DivisionID { get; set; }
        [DataMember]
        [StringLength(50)]
        public string Name { get; set; }


        public virtual User OwnerID { get; set; }

        //public static Division getById(int id)
        //{
        //    return Division.FindByPrimaryKey(id);
        //}

        //public static List<Division> getAll()
        //{
        //    return Division.FindAll().ToList();
        //}
     
        //public void remove()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
