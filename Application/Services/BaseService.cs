using AppCore.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public abstract class BaseService<T> : IService<T>
    {
        private IModel<T> model;

        protected BaseService(IModel<T> model)
        {
            this.model = model;
        }

        public void Add(T t, ref T[] data)
        {
            model.Add(t, ref data);
        }

        public void Create(T t)
        {
            model.Create(t);
        }

        public bool Delete(T t)
        {
            return model.Delete(t);
        }

        public T[] FindAll()
        {
            return model.FindAll();
        }

        public int GetLastId()
        {
            return model.GetLastId();
        }

        public int Update(T t)
        {
            return model.GetLastId();
        }
    }
}
