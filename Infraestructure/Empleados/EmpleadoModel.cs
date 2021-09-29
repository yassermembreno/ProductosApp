using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Empleados
{
    public class EmpleadoModel
    {
        private Empleado[] empleados;

        public void Create(Empleado e)
        {
            if(empleados == null)
            {
                empleados = new Empleado[1];
                empleados[0] = e;
                return;
            }

            Empleado[] temp = new Empleado[empleados.Length + 1];
            Array.Copy(empleados,temp,empleados.Length);
            temp[temp.Length - 1] = e;

            empleados = temp;
        }

        public int GetLastEmpleadoId()
        {
            return empleados == null ? 0 : empleados[empleados.Length - 1].Id;
        }

        public Empleado[] GetEmpleados()
        {
            return empleados;
        }
    }
}
