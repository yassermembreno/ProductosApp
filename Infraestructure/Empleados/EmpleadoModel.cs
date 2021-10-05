using Domain.Entities.Empleados;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Empleados
{
    public class EmpleadoModel : IEmpleadoModel
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
            Array.Copy(empleados, temp, empleados.Length);
            temp[temp.Length - 1] = e;

            empleados = temp;
        }

        public int GetLastEmpleadoId()
        {
            return empleados == null ? 0 : empleados[empleados.Length - 1].Id;
        }
      
        public Empleado FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Empleado t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Empleado t)
        {
            throw new NotImplementedException();
        }

        public Empleado[] FindAll()
        {
            return empleados;
        }
    }
}
