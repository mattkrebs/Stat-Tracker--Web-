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
        public List<Team> GetAll()
        {
            using (var ctx = new StatContext())
            {
                return ctx.Teams.ToList();
            }
        }

        public List<Team> GetAll(Guid OwnerId)
        {
            using (var ctx = new StatContext())
            {
                List<Team> teams = ctx.Teams.Where(x => x.Owner.UserID == OwnerId).ToList();
                return teams;
            }
        }







        #region ICoreService<Team> Members
        

        public Team Create(Team obj, Guid OwnerId)
        {
            using (var ctx = new StatContext())
            {
                obj.Owner = ctx.Users.FirstOrDefault(x => x.UserID == OwnerId);
                obj.DateCreated = DateTime.Now;
                obj.DateMotified = DateTime.Now;
                ctx.Teams.Add(obj);
                ctx.SaveChanges();
                return obj;
            }
        }

        public Team Update(Team obj, Guid OwnerId)
        {
            using (var ctx = new StatContext())
            {
                Team team = ctx.Teams.Find(obj.TeamID);
                if (team.Owner.UserID == OwnerId)
                {
                    
                    if (obj.TeamName != team.TeamName)
                        team.TeamName = obj.TeamName;
                    if (obj.PhotoUrl != team.PhotoUrl)
                        team.PhotoUrl = obj.PhotoUrl;

                    team.DateMotified = DateTime.Now;
                    ctx.Entry(team).State = System.Data.EntityState.Modified;
                    int i =  ctx.SaveChanges();
                    
                }
                return team;
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


        public Team GetById(int id)
        {
            using (var ctx = new StatContext())
            {
                return ctx.Teams.Include("Players").Where(x => x.TeamID == id).FirstOrDefault();
            }
        }

        #endregion

        public List<Team> GetAllByLeagueId(int id)
        {
            using (var ctx = new StatContext())
            {
             
                return ctx.Teams.Where(x => x.League.LeagueID == id).ToList();
            }
        }

       
    }
}
