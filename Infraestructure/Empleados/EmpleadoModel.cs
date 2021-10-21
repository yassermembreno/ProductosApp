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

        #region Private Methods
        public void Add(Empleado e)
        {
            if (empleados == null)
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

        private int GetIndex(int Id)
        {
            int index = int.MinValue, i = 0;
            
            foreach (Empleado emp in empleados)
            {
                if(emp.Id == Id)
                {
                    index = i;
                    break;
                }

                i++;
            }

            return index;
        }

        #endregion
        public int GetLastEmpleadoId()
        {
            return empleados == null ? 0 : empleados[empleados.Length - 1].Id;
        }
        public Empleado[] GetEmpleados()
        {
            return empleados;
        }
        
        public Empleado FindById(int id)
        {
            if(empleados == null)
            {
                return null;
            }

            if(id < 0 || id > empleados.Length)
            {
                return null;
            }

            int index = GetIndex(id);
            return index < 0 ? null : empleados[index];
        }

        public void Create(Empleado t)
        {
            Add(t);
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

        public int GetLastId()
        {
            throw new NotImplementedException();
        }

        public void Add(Empleado t, ref Empleado[] data)
        {
            throw new NotImplementedException();
        }
    }
}
