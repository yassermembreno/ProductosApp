using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public abstract class Empleado
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaContratacion { get; set; }

        public abstract string GetEmpleadoAsString();
    }
}
