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
    public class UserService : ICoreService<User>
    {
        public static User GetOwner(Guid UserID)
        {
            using (var ctx = new StatContext())
            {
                return ctx.Users.Find(UserID).Owner;
            }
        }

        #region ICoreService<User> Members

        public IList<User> GetAll(Guid UserID)
        {
            throw new NotImplementedException();
        }

        public void Create(User obj, Guid UserID)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj, Guid UserID)
        {
            throw new NotImplementedException();
        }

        public void Delete(User obj, Guid UserID)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICoreService<User> Members


        public User GetById(int Id)
        {
            throw new NotImplementedException();
        }

        #endregion



        public static string Login(string user, string password, string apikey)
        {
            if (CodeFirstSecurity.ValidateUser(user, password, apikey))
            {
                return CodeFirstCrypto.GenerateToken();
            }
            else
            {
               return ("The user name, password or api key provided is incorrect.");
            }
        }
    }
}
