using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Producto : IComparable<Producto>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public decimal Precio { get; set; }
        public DateTime Vencimiento { get; set; }
        public UnidadMedida UnidadMedida { get; set; }

        public int CompareTo(Producto other)
        {
            return new ProductoIdCompare().Compare(this, other);
        }

        public class ProductoIdCompare : IComparer<Producto>
        {
            public int Compare(Producto x, Producto y)
            {
                if(x.Id > y.Id)
                {
                    return 1;
                }
                else if(x.Id < y.Id)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
