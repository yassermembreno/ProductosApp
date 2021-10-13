using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Processses
{
    public interface ISalaryCalculator
    {
        decimal CalculateSalary(Empleado e);
    }
}
