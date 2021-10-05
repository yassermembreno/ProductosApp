using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IEmpleadoModel : IModel<Empleado>
    {
        Empleado FindById(int id);

        int GetLastEmpleadoId();
    }
}
