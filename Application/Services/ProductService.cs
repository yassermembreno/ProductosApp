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
    public class ProductService : BaseService<Producto>, IProductService
    {
        private IProductRepository productoRepository;

        public ProductService(IProductRepository productoRepository) : base(productoRepository)
        {
            this.productoRepository = productoRepository;
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

    }
}
