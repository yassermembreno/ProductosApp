using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public class EmpleadoDocente : Empleado
    {
        public TipoContratacion TipoContratacion { get; set; }
        public EmpleadoDocente(int codigo, string cedula, string nombres, string apellidos, decimal salario, DateTime fechaContratacion) : base(codigo, cedula, nombres,  apellidos,  salario,  fechaContratacion)
        {

        }

       
        public override string GetEmpleadoAsString()
        {
            throw new NotImplementedException();
        }
    }
}
