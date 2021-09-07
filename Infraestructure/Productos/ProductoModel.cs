using Domain.Entities;
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
            Add(p,ref productos);
        }

        public int Update(Producto p)
        {
            int index = GetIndexById(p);
            if(index < 0)
            {
                throw new Exception($"El producto con Id {p.Id} no se encontro.");
            }

            productos[index] = p;
            return index;
        }

        public bool Delete(Producto p)
        {
            int index = GetIndexById(p);
            if (index < 0)
            {
                throw new Exception($"El producto con Id {p.Id} no se encontro.");
            }

            if(index != productos.Length - 1)
            {
                productos[index] = productos[productos.Length - 1];
            }

            Producto[] tmp = new Producto[productos.Length - 1];
            Array.Copy(productos,tmp,tmp.Length);
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
            Array.Sort(productos, new Producto.ProductoIdCompare());
            int index = Array.BinarySearch(productos, id);
            
            return index < 0 ? null : productos[index];
        }
        #endregion

        #region private method
        private void Add(Producto p, ref Producto[] pds)
        {
            if(pds == null)
            {
                pds = new Producto[1];
                pds[pds.Length - 1] = p;
                return;
            }
            Producto[] tmp = new Producto[pds.Length + 1];
            Array.Copy(pds,tmp,pds.Length);
            pds = tmp;            
        }

        private int GetIndexById(Producto p)
        {   
            if(p == null)
            {
                throw new ArgumentException("El producto no puede ser null.");
            }
            int index = int.MinValue;
            if (productos == null)
            {
                return index;
            }
            int i = 0;
            foreach(Producto pd in productos)
            {
                if(pd.Id == p.Id)
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
