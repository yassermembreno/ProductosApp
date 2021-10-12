using AppCore.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class ProductoService : IProductoService
    {
        private IProductoModel productoModel;

        public ProductoService(IProductoModel productoModel)
        {
            this.productoModel = productoModel;
        }

        public void Create(Producto t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            try
            {
                productoModel.Create(t);   
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public bool Delete(Producto t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            try
            {
                return productoModel.Delete(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Producto[] FindAll()
        {
            return productoModel.FindAll();
        }

        public int GetLastProductoId()
        {
            return productoModel.GetLastProductoId();
        }

        public Producto GetProductoById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException($"El id: {id} no es valido.");
            }   
            return productoModel.GetProductoById(id);
        }

        public string GetProductosAsJson()
        {
            return productoModel.GetProductosAsJson();
        }

        public Producto[] GetProductosByFechaVencimiento(DateTime dt)
        {
            return productoModel.GetProductosByFechaVencimiento(dt);
        }

        public Producto[] GetProductosByRangoPrecio(decimal start, decimal end)
        {
            return productoModel.GetProductosByRangoPrecio(start, end);
        }

        public Producto[] GetProductosByUnidadMedida(UnidadMedida um)
        {
            return productoModel.GetProductosByUnidadMedida(um);
        }

        public Producto[] GetProductosOrderByPrecio()
        {
            return productoModel.GetProductosOrderByPrecio();
        }

        public int Update(Producto t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(nameof(t));
            }

            try
            {
                return productoModel.Update(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
