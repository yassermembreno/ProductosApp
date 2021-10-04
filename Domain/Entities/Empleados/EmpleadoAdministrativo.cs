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

        public EmpleadoAdministrativo(int codigo, string cedula, string nombres, string apellidos, decimal salario, DateTime fechaContratacion) : base(codigo, cedula, nombres, apellidos, salario, fechaContratacion)
        {

        }

        public override string GetEmpleadoAsString()
        {
            throw new NotImplementedException();
        }
    }
}
