using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatTrackr.Framework.Domain;
using StatTrackr.Framework;
using System.Data.Entity;


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


        public User GetById(dynamic Id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
