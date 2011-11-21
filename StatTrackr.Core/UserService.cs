using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework;
using System.Data.Entity;
using StatTrackr.Framework.Security;


namespace StatTrackr.Core
{
    public class UserService 
    {
        public static User GetOwner(Guid UserID)
        {
            using (var ctx = new StatContext())
            {
                Guid ownerid = ctx.Users.Find(UserID).Owner.UserID;
                return ctx.Users.FirstOrDefault(x => x.UserID == ownerid);
            }
        }


        #region ICoreService<User> Members


        public User GetById(int Id)
        {
            throw new NotImplementedException();
        }

        #endregion



        public static string Login(string user, string password, string apikey)
        {
            return CodeFirstSecurity.ValidateUser(user, password, apikey);
        }

        public static User GetOwner(string token)
        {
            using (var ctx = new StatContext())
            {
                User u = ctx.Users.FirstOrDefault(x => x.LoginToken == token && x.LoginTokenExpirationDate > DateTime.Now);
                return ctx.Users.Include("Owner").FirstOrDefault(x => x.LoginToken == token && x.LoginTokenExpirationDate > DateTime.Now).Owner;
            }
        }
    }
}
