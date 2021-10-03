using Domain.Enums.Activos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Activos
{
    public class ActivoFijo
    {
        public int Id { get; set; }
        public string CodigoActivo { get; set; }
        public string NombreActivo { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorActivo { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public TipoActivoFijo TipoActivoFijo { get; set; }
        public MetodoDepreciacion MetodoDepreciacion { get; set; }

        public override string ToString()
        {
            return string.Format("{0,5:d} {1,-20} {2,-15} {3,5:f} {4,-30:d} {5,4:d} \n", $"{Id}",$"{CodigoActivo}", $"{NombreActivo}", $"{ValorActivo}", $"{FechaAdquisicion}", $"{TipoActivoFijo}");
        }
    }
}
