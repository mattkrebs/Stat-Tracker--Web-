using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace StatTrackr.Framework.Domain
{
    public class Role : DomainBase
    {
        //Membership required
        [Key()]
        public virtual int RoleID { get; set; }
        [Required()]
        [MaxLength(100)]
        public virtual string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }

        //Optional
        [MaxLength(250)]
        public virtual string Description { get; set; }  
       
        
    }
}
