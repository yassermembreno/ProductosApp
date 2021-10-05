using AppCore.Interfaces;
using Domain.Entities.Empleados;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class EmpleadoServices : IEmpleadoServices
    {
        private IEmpleadoModel empleadoModel;

        public EmpleadoServices(IEmpleadoModel empleadoModel)
        {
            this.empleadoModel = empleadoModel;
        }
        public void Create(Empleado e)
        {
            empleadoModel.Create(e);
        }

        public bool Delete(Empleado e)
        {
            return empleadoModel.Delete(e);
        }

        public Empleado FindById(int id)
        {
            return empleadoModel.FindById(id);
        }

        public int Update(Empleado e)
        {
            return empleadoModel.Update(e);
        }

        public Empleado[] FindAll()
        {
            return empleadoModel.FindAll();
        }
        public int GetLastEmpleadoId()
        {
            return empleadoModel.GetLastEmpleadoId();
        }

    }
}
