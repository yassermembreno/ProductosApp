using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Empleados;

namespace AppCore.Processses.Payroll
{
    public class AdmnistrativoSalaryCalculator : BaseSalaryCalculator, ISalaryCalculator
    {
        public decimal CalculateSalary(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado));
            }

            decimal partialSalary = (empleado.Salario + CalculateExtaHourSalary(((Administrativo)empleado).HorasExtras, CalculateSalaryPerHour(empleado.Salario)));
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
