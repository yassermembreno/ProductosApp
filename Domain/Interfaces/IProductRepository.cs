using Domain.Entities.Inventories;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IProductRepository : IModel<Producto>
    {
        Producto GetProductoById(int id);
        Producto[] GetProductosByUnidadMedida(MeasureUnit um);
        string GetProductosAsJson();    
    }
}
