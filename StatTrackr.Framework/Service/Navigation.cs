using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework.Helpers;
using StatTrackr.Framework.Security;

namespace StatTrackr.Framework.Service
{
    public class Navigation
    {

        public List<Division> divisions { get; set; }
        public List<League> leagues { get; set; }
        public List<Team> teams { get; set; }

        public Navigation()
        {
            divisions = new List<Division>();
            leagues = new List<League>();
            teams = new List<Team>();
        }

        public static Navigation GetByUserId(Guid user)
        {
            return STCacheHelper.GetNavigationByUserId(user);
        }

        public static Navigation GetByCurrentUser()
        {
            return GetByUserId(CodeFirstSecurity.CurrentUserId);
        }

    }
}
