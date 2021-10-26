using Domain.Entities.Inventories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Interfaces
{
    public interface IProductService : IService<Producto>
    {
        Producto GetProductoById(int id);
        Producto[] GetProductosByUnidadMedida(MeasureUnit um);      
        string GetProductosAsJson();

        ProductItem[] GetProductsItems();
        ProductItem GetProductsItems(int productId);
    }
}
