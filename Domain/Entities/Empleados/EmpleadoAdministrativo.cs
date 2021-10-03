using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public class EmpleadoAdministrativo : Empleado
    {
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public int HorasExtras { get; set; }//Diarias Minimo 1; Maximo 3 horas
       
        public EmpleadoAdministrativo(int codigo, string nombres, string apellidos, string nid) : base(codigo,nombres, apellidos, nid)
        {
        }

        public override string PrintEmpleado()
        {
            return $"HoraEntrada:{HoraEntrada}, HoraSalida{HoraSalida}";
        }
    }
}
