using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Productos
{
    public class ProductoModel
    {
        private Producto[] productos;

        #region CRUD
        public void Add(Producto p)
        {
            Add(p, ref productos);
        }

        public int Update(Producto p)
        {
            if(p == null)
            {
                throw new ArgumentException("El producto no puede ser null.");
            }

            int index = GetIndexById(p.Id);
            if(index < 0)
            {
                throw new Exception($"El producto con id {p.Id} no se encuentra.");
            }

            productos[index] = p;
            return index;
        }

        public bool Delete(Producto p)
        {
            if (p == null)
            {
                throw new ArgumentException("El producto no puede ser null.");
            }

            int index = GetIndexById(p.Id);
            if (index < 0)
            {
                throw new Exception($"El producto con id {p.Id} no se encuentra.");
            }

            if(index != productos.Length - 1)
            {
                productos[index] = productos[productos.Length - 1];
            }

            Producto[] tmp = new Producto[productos.Length - 1];
            Array.Copy(productos, tmp, tmp.Length);
            productos = tmp;

            return productos.Length == tmp.Length;
        }
        public Producto[] GetAll()
        {
            return productos;
        }

        #endregion

        #region Queries
        public Producto GetProductoById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException($"El Id: {id} no es valido.");
            }

            int index = GetIndexById(id);            

            return index <= 0 ? null : productos[index];
        }

        public Producto[] GetProductosByUnidadMedida(UnidadMedida um)
        {
            return null;
        }
        #endregion

        #region Private Method
        private void Add(Producto p, ref Producto[] pds)
        {
            if(pds == null)
            {
                pds = new Producto[1];
                pds[pds.Length - 1] = p;
                return;
            }

            Producto[] tmp = new Producto[pds.Length + 1];
            Array.Copy(pds, tmp, pds.Length);
            tmp[tmp.Length - 1] = p;
            pds = tmp;
        }

        private int GetIndexById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException("El id no puede ser negativo o cero.");
            }

            int index = int.MinValue, i = 0;
            if(productos == null)
            {
                return index;
            }

            foreach (Producto p in productos)
            {
                if(p.Id == id)
                {
                    index = i;
                    break;
                }
                i++;
            }

            return index;
        }
        #endregion
    }
}
