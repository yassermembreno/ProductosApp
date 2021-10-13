using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Empleados;

namespace AppCore.Processses
{
    public class DocenteSalaryCalculator : BaseSalaryCalculator, ISalaryCalculator
    {
        public decimal CalculateSalary(Empleado e)
        {            
            decimal inss = CalculateInss(e.Salario);
            decimal annualSalary = CalculateAnnualSalary(e.Salario - inss);            
            decimal ir = CalculateIr(annualSalary);           

            return e.Salario - inss - ir;
        }
    }
}
