﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatTrackr.Core
{
    public interface ICoreService<T>
    {
        //List<T> GetAll(Guid UserID);

        T GetById(int Id);

        void Create(T obj, Guid UserID);

        void Update(T obj, Guid UserID);

        void Delete(T obj, Guid UserID);

        

    }
}
