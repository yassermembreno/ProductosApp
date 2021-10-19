using AppCore.Interfaces;
using Domain.Entities.Inventories;
using Domain.Enums;
using Domain.Interfaces;
using Infraestructure.Inventories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productoRepository;

        public ProductService(IProductRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }
        public void Create(Producto t)
        {
            productoRepository.Create(t);
        }

        public bool Delete(Producto t)
        {
            throw new NotImplementedException();
        }

        public Producto[] FindAll()
        {
            return productoRepository.FindAll();
        }

        public int GetLastProductoId()
        {
            return productoRepository.GetLastProductoId();
        }

        public Producto GetProductoById(int id)
        {
            return productoRepository.GetProductoById(id);
        }

        public string GetProductosAsJson()
        {
            throw new NotImplementedException();
        }

        public Producto[] GetProductosByUnidadMedida(MeasureUnit um)
        {
            throw new NotImplementedException();
        }

        public int Update(Producto t)
        {
            throw new NotImplementedException();
        }
    }
}
