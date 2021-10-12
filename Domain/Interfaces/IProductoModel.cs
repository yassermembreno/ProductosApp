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
        Producto[] GetProductosByFechaVencimiento(DateTime fv);
        Producto[] GetProductosByRangoPrecio(decimal low, decimal high);
        Producto[] GetProductosOrderByPrecio();
        string GetProductosAsJson();

        int GetLastProductoId();

    }
}
