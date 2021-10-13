using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IProductoModel : IModel<Producto>
    {
        Producto GetProductoById(int id);
        Producto[] GetProductosByUnidadMedida(UnidadMedida um);

        Producto[] GetProductosByFechaVencimiento(DateTime dt);

        Producto[] GetProductosByRangoPrecio(decimal start, decimal end);

        string GetProductosAsJson();

        Producto[] GetProductosOrderByPrecio();

        int GetLastProductoId();        
    }
}
