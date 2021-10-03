using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public class EmpleadoDocente : Empleado
    {
        public TipoContratacion TipoContratacion { get; set; }
        public EmpleadoDocente(int codigo, string nombres, string apellidos, string nid) : base(codigo,nombres,apellidos,nid)
        {

        }

        public override string PrintEmpleado()
        {
            return $"Codigo:{Codigo}, Nombres{Nombres}, Apellidos:{Apellidos}, Cedula:{NumeroIdentificacion}";
        }

        public override string PrintEmpleadoV2()
        {
            return $"{base.PrintEmpleadoV2()}, Nombres:{Nombres}";
        }
    }
}
