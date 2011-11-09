using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.Core
{
    public interface ICoreService<T>
    {
        IList<T> GetAll(Guid UserID);

        T GetById(dynamic Id);

        void Create(T obj, Guid UserID);

        void Update(T obj, Guid UserID);

        void Delete(T obj, Guid UserID);

        

    }
}
