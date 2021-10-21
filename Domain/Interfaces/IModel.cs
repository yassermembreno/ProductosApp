using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IModel<T>
    {
        void Create(T t);
        int Update(T t);
        bool Delete(T t);
        T[] FindAll();
        int GetLastId();
        void Add(T t, ref T[] data);
    }
}
