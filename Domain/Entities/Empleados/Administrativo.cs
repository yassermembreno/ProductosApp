using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public class Administrativo : Empleado
    {
        public float HorasExtras { get; set; }

        public override string GetEmpleadoAsString()
        {
            return string.Format("{0,5:d} {1,-20} {2,-20} {3,-20} {4,15:F} {5,-20:d} {6,-5:f} \n",
                $"{Codigo}", $"{Cedula}", $"{Nombres}", $"{Apellidos}", $"{Salario}",
                $"{FechaContratacion}", $"{HorasExtras}");
        }
    }
}
