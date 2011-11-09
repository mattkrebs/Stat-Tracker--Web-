using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace StatTrackr.Framework.Domain
{
    public class Region : DomainBase
    {
        [Key()]
        public int RegionID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string TimeZone { get; set; }
        public virtual Division Division { get; set; }
    }
}
