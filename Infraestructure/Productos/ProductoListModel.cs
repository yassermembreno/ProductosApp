using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Productos
{
    public class ProductoListModel : IProductoModel
    {
        private List<Producto> productos;

        public void Create(Producto t)
        {
            productos.Add(t);
        }

        public bool Delete(Producto t)
        {            
            return productos.Remove(t);
        }

        public Producto[] FindAll()
        {
            return productos.ToArray();
        }

        public int GetLastProductoId()
        {
            return productos == null ? 0 : productos[productos.Count - 1].Id;
        }

        public Producto GetProductoById(int id)
        {
            throw new NotImplementedException();
        }

        public string GetProductosAsJson()
        {
            throw new NotImplementedException();
        }

        public Producto[] GetProductosByFechaVencimiento(DateTime fv)
        {
            throw new NotImplementedException();
        }

        public Producto[] GetProductosByRangoPrecio(decimal low, decimal high)
        {
            throw new NotImplementedException();
        }

        public Producto[] GetProductosByUnidadMedida(UnidadMedida um)
        {
            throw new NotImplementedException();
        }

        public Producto[] GetProductosOrderByPrecio()
        {
            throw new NotImplementedException();
        }

        public int Update(Producto t)
        {
            throw new NotImplementedException();
        }
    }
}
