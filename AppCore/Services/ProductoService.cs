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
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException(nameof(t));
                }

                productoModel.Create(t);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public bool Delete(Producto t)
        {
            bool success;
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException(nameof(t));
                }

                success = productoModel.Delete(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
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
            Producto producto;
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentNullException($"id: {id} no es valido.");
                }

                producto = productoModel.GetProductoById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return producto;
        }

        public string GetProductosAsJson()
        {
            return productoModel.GetProductosAsJson();
        }

        public Producto[] GetProductosByFechaVencimiento(DateTime fv)
        {
            return productoModel.GetProductosByFechaVencimiento(fv);
        }

        public Producto[] GetProductosByRangoPrecio(decimal low, decimal high)
        {
            return productoModel.GetProductosByRangoPrecio(low, high);
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
            int index;
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException(nameof(t));
                }

                index = productoModel.Update(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return index;
        }
    }
}
