using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public class Docente : Empleado
    {
        public CategoriaDocente CategoriaDocente { get; set; }

        public Docente(int codigo, string nombres, string apellidos, string cedula, decimal salario) : 
            base(codigo, nombres, apellidos)
        {
            Cedula = cedula;
            Salario = salario;
        }
        public override string GetEmpleadoAsString()
        {
            return string.Format("{0,-10} {1,-20} {2,-20} {3,-16} {4,10:f} {5,-20} \n",
                $"{CodigoEmpleado}", $"{Nombres}", $"{Apellidos}", 
                $"{Cedula}", $"{Salario}", $"{CategoriaDocente}");
        }
    }
}
