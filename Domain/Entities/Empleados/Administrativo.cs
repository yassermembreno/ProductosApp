using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Empleados
{
    public class Administrativo : Empleado
    {
        public float HorasExtras { get; set; }

        public Administrativo(int codigo, string cedula, string nombres, 
            string apellidos, decimal salario, DateTime fechaContratacion) : 
            base(codigo, cedula, nombres, apellidos, salario, fechaContratacion)
        {

        }

        public override string GetEmpleadoAsString()
        {
            return string.Format("{0,5:d} {1,20} {2,20} {3,20} {4,7:f} {5,20:d} {6,20:f} \n",
                $"{Codigo}", $"{Cedula}", $"{Nombres}", $"{Apellidos}",
                $"{Salario}", $"{FechaContratacion}", $"{HorasExtras}");
        }
    }
}
