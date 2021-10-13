using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Processses.Payroll
{
    public interface ISalaryCalculator
    {
        decimal CalculateSalary(Empleado empleado);
    }
}
