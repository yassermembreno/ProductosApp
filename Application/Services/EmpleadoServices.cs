using AppCore.Interfaces;
using Domain.Entities.Empleados;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class EmpleadoServices : BaseService<Empleado>, IEmpleadoServices
    {
        private IEmpleadoModel empleadoModel;

        public EmpleadoServices(IEmpleadoModel empleadoModel) : base(empleadoModel)
        {
            this.empleadoModel = empleadoModel;
        }       
        public Empleado FindById(int id)
        {
            return empleadoModel.FindById(id);
        }       
       
    }
}
