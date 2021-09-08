using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Producto
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Nombre { get; set; }
        [JsonProperty]
        public string Descripcion { get; set; }
        [JsonProperty]
        public int Existencia { get; set; }
        [JsonProperty]
        public decimal Precio { get; set; }
        [JsonProperty]
        public DateTime FechaVencimiento { get; set; }
        [JsonProperty]
        public UnidadMedida UnidadMedida { get; set; }

        public class ProductoPrecioComparer : IComparer<Producto>
        {
            public int Compare(Producto x, Producto y)
            {
                if(x.Precio > y.Precio)
                {
                    return 1;
                }else if(x.Precio < y.Precio)
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
