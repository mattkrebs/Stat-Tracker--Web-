using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.Core
{
    public interface ICoreService<T>
    {
        //List<T> GetAll(Guid UserID);

        T GetById(int Id, Guid UserID);

        T Create(T obj, Guid UserID);

        T Update(T obj, Guid UserID);

        void Delete(T obj, Guid UserID);

        

    }
}
