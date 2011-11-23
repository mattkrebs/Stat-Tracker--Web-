using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.Entity;
using StatTrackr.Framework.Domain.Base;
using System.ComponentModel.DataAnnotations;
using StatTrackr.Framework.Security;

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

        public virtual User Owner { get; set; }

        public static List<Division> GetAllDivisionsByUserId(Guid userId)
        {
            List<Division> divisions = new List<Division>();

            using (var ctx = new StatContext())
            {

                var results = from e in ctx.Divisions
                              where e.Owner.UserID == userId
                              select e;

                divisions = results.ToList<Division>();
            }

            return divisions;
        }

        public static List<Division> GetAllDivisionsByCurrentUser()
        {
            return GetAllDivisionsByUserId(CodeFirstSecurity.CurrentUserId);
        }

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
