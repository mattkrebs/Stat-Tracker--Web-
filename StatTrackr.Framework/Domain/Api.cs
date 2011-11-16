using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace StatTrackr.Framework.Domain
{
    public class Api : DomainBase
    {
        [Key()]
        public string ApiKey { get; set; }
        public DateTime ExparationDate { get; set; }
        public virtual User User { get; set; }
        
    }
}
