using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework;

namespace StatTrackr.Core
{
    public class TeamService : ICoreService<Team>
    {
        // Gets All Teams By looking up the Owner ID and retrieving by that
        public IList<Team> GetAll(Guid UserID)
        {
            using (var ctx = new StatContext())
            {
                return ctx.Teams.Where(x => x.Owner == UserService.GetOwner(UserID)).ToList();
            }
        }

        public IList<Team> GetAll()
        {
            using (var ctx = new StatContext())
            {
                return ctx.Teams.ToList();
            }
        }







        #region ICoreService<Team> Members


        public void Create(Team obj, Guid UserID)
        {
            using (var ctx = new StatContext())
            {
                obj.Owner = UserService.GetOwner(UserID);
                ctx.Teams.Add(obj);
                ctx.SaveChanges();
            }
        }

        public void Update(Team obj, Guid UserID)
        {
            using (var ctx = new StatContext())
            {
                if (obj.Owner == UserService.GetOwner(UserID)){
                    ctx.Entry(obj).State = System.Data.EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public void Delete(Team obj, Guid UserID)
        {
           using (var ctx = new StatContext())
            {
                if (obj.Owner == UserService.GetOwner(UserID)){
                    ctx.Entry(obj).State = System.Data.EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
        }

        #endregion

        #region ICoreService<Team> Members


        public Team GetById(dynamic Id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
