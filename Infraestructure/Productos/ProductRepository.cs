using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Productos
{
    public class ProductRepository : IProductRepository
    {
        private List<Producto> productos;

        public ProductRepository()
        {
            productos = new List<Producto>();
        }

        public void Create(Producto t)
        {
            productos.Add(t);
        }

        public bool Delete(Producto t)
        {
            return productos.Remove(t);
        }

        public ICollection<Producto> FindAll(Predicate<Producto> predicate)
        {
            if (predicate == null)
            {
                return null;
            }
            return productos.FindAll(predicate);
        }

        public ICollection<Producto> FindAll()
        {
            return this.productos;
        }

        public Producto FindAny(Predicate<Producto> predicate)
        {
            if(predicate == null)
            {
                return null;
            }
            return productos.Find(predicate);
        }

        public int Update(Producto t)
        {
            int index = productos.IndexOf(t);
            if (index < 0)
            {
                throw new Exception($"El producto con Id {t.Id} no existe.");
            }
            productos.Insert(index, t);
            return index;

        }
    }
}
