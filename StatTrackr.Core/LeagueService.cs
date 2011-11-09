using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework;
using StatTrackr.Framework.Domain;

namespace StatTrackr.Core
{
    public class LeagueService : ICoreService<League>
    {

        #region ICoreService<League> Members

        public IList<League> GetAll(Guid UserID)
        {
            using (var ctx = new StatContext())
            {
                User Owner = UserService.GetOwner(UserID);
                return ctx.Leagues.Where(x => x.Owner.UserID == Owner.UserID).ToList(); 
            }
        }

        public void Create(League obj, Guid UserID)
        {
            throw new NotImplementedException();
        }

        public void Update(League obj, Guid UserID)
        {
            throw new NotImplementedException();
        }

        public void Delete(League obj, Guid UserID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICoreService<League> Members


        public League GetById(dynamic Id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
