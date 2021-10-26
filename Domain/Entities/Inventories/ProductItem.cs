using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventories
{
    public class ProductItem
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public MeasureUnit UnidadMedida { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
