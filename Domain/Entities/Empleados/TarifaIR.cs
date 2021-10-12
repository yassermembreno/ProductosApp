using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public class TarifaIR
    {
        public decimal Desde { get; set; }
        public decimal Hasta { get; set; }
        public decimal ImpuestoBase { get; set; }
        public decimal PorcentajeAplicable { get; set; }
        public decimal SobreExceso { get; set; }
    }
}
