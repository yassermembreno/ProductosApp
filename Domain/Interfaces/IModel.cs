using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IModel<T> //CRUD => Create, Read, Update, Delete
    {
        void Create(T t);
        int Update(T t);
        bool Delete(T t);
        T[] FindAll();
    }
}
