using AppCore.Interfaces;
using Domain.Entities.Empleados;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private IEmpleadoModel empleadoModel;

        public EmpleadoService(IEmpleadoModel empleadoModel)
        {
            this.empleadoModel = empleadoModel;
        }
        public void Create(Empleado t)
        {
            empleadoModel.Create(t);
        }

        public bool Delete(Empleado t)
        {
            return empleadoModel.Delete(t);
        }

        public Empleado[] FindAll()
        {
            return empleadoModel.FindAll();
        }

        public Empleado FindById(int id)
        {
            return empleadoModel.FindById(id);
        }

        public int GetLastEmpleadoId()
        {
            return empleadoModel.GetLastEmpleadoId();
        }

        public int Update(Empleado t)
        {
            return empleadoModel.Update(t);
        }
    }
}
