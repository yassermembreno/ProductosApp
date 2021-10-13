using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Empleados;

namespace AppCore.Processses
{
    public class AdministrativoSalaryCalculator : BaseSalaryCalculator, ISalaryCalculator
    {
        public decimal CalculateSalary(Empleado e)
        {              
            decimal partialSalary = (e.Salario + CalculateExtaHourSalary(((Administrativo)e).HorasExtras, CalculateSalaryPerHour(e.Salario)));
            decimal inss = CalculateInss(partialSalary);
            decimal annualSalary = CalculateAnnualSalary(partialSalary - inss);
            decimal ir = CalculateIr(annualSalary);

            return partialSalary - inss - ir;
        }
        private decimal CalculateSalaryPerHour(decimal salary)
        {
            return salary / 160;
        }

        private decimal CalculateExtaHourSalary(float horasExtras, decimal salaryPerHour)
        {
            return (decimal)horasExtras * salaryPerHour;
        }
    }
}
