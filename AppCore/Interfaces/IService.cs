using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IService<T> // CRUD
    {
        void Create(T t);
        int Update(T t);
        bool Delete(T t);
        T[] FindAll();
    }
}
