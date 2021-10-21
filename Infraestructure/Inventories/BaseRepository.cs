using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infraestructure.Inventories
{
    public abstract class BaseRepository<T> : IModel<T>
    {
        protected T[] data;

        public void Create(T t)
        {
            Add(t,ref data);
        }

        public bool Delete(T t)
        {           
            if(t == null)
            {
                return false;
            }

            if(data == null)
            {
                throw new Exception("No hay elementos para eliminar.");
            }

            int index = GetIndex(t);

            if(index < 0)
            {
                return false;
            }

            if (index != data.Length - 1)
            {
                data[index] = data[data.Length - 1];
            }

            T[] tmp = new T[data.Length - 1];
            Array.Copy(data, tmp, tmp.Length);
            data = tmp;

            return data.Length == tmp.Length;
        }

        public T[] FindAll()
        {
            return data;
        }

        public int Update(T t)
        {
            if (t == null)
            {
                throw new ArgumentException("Objeto no valido.");
            }

            if (data == null)
            {
                throw new Exception("No hay elementos para modificar.");
            }

            int index = GetIndex(t);

            if(index < 0)
            {
                throw new Exception($"El objeto con id:{t.GetType().GetProperty("Id")} no se encuentra.");
            }

            data[index] = t;

            return index;
        }

        protected int GetIndex(T t)
        {
            int index = int.MinValue, i = 0;
            int? id = (int)t.GetType().GetProperty("Id")?.GetValue(t);

            if(id == null)
            {
                throw new ArgumentException($"El objeto {t.GetType().Name} no contiene la propiedad Id");
            }

            foreach(T e in data)
            {
                int key = (int)t.GetType().GetProperty("Id").GetValue(e);
                if (id == key)
                {
                    index = i;
                    break;
                }
                i++;
            }

            return index;
        }

        public void Add(T t, ref T[] data)
        {
            if (data == null)
            {
                data = new T[1];
                data[0] = t;
                return;
            }

            T[] tmp = new T[data.Length + 1];
            Array.Copy(data, tmp, data.Length);
            tmp[tmp.Length - 1] = t;
            data = tmp;
        }

        public int GetLastId()
        {   
            return data == null ? 0 : (int)data[data.Length - 1].GetType().GetProperty("Id").GetValue(data[data.Length - 1]);
        }

    }
}
