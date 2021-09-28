using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public abstract class Empleado
    {
        protected int CodigoEmpleado {get;set;}
        protected string Nombres { get; set; }
        protected string Apellidos { get; set; }
        protected string Cedula { get; set; }
        protected decimal Salario { get; set; }

        protected Empleado(int codigo, string nombres, string apellidos)
        {
            CodigoEmpleado = codigo;
            Nombres = nombres;
            Apellidos = apellidos;
        }

        public abstract string GetEmpleadoAsString();    
    }
}
