using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public class Docente : Empleado
    {
        public CategoriaDocente CategoriaDocente { get; set; }

        public override string GetEmpleadoAsString()
        {
            return string.Format("{0,5:d} {1,-20} {2,-20} {3,-20} {4,15:F} {5,-20:d} {6,-20} \n",
                $"{Codigo}", $"{Cedula}", $"{Nombres}", $"{Apellidos}", $"{Salario}", 
                $"{FechaContratacion}", $"{CategoriaDocente}");
        }
    }
}
