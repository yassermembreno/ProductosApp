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

        protected Empleado(int codigo, string cedula, string nombres, string apellidos, decimal salario, DateTime fechaContratacion)
        {
            Codigo = codigo;
            Cedula = cedula;
            Nombres = nombres;
            Apellidos = apellidos;
            Salario = salario;
            FechaContratacion = fechaContratacion;
        }

        public abstract string GetEmpleadoAsString();

    }
}
