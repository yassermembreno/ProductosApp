using AppCore.Interfaces;
using Domain.Entities.Inventories;
using Domain.Enums;
using Domain.Interfaces;
using Infraestructure.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCore.Services
{
    public class ProductService : BaseService<Producto>, IProductService
    {
        private IProductRepository productoRepository;
        private IItemRepository itemRepository;

        public ProductService(IProductRepository productoRepository, IItemRepository itemRepository) : base(productoRepository)
        {
            this.productoRepository = productoRepository;
            this.itemRepository = itemRepository;
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

        public ProductItem[] GetProductsItems()
        {
            throw new NotImplementedException();
        }

        public ProductItem GetProductsItems(int productId)
        {
            Producto p = productoRepository.GetProductoById(productId);
            Item[] items = itemRepository.FindByProductId(p.Id);

            Array.Sort(items, (a, b) => a.ExpirationDate.CompareTo(b.ExpirationDate));

            return new ProductItem()
            {
                Cantidad = items.Select(i => i.Available).Sum(),
                FechaVencimiento = items.Select(i => i.ExpirationDate).Last(),
                Nombre = $"{p.Nombre} - {p.Descripcion}",
                Precio = items.Select(i => i.MaximumRetailPrice).Last(),
                UnidadMedida = p.UnidadMedida
            };
        }
    }
}
