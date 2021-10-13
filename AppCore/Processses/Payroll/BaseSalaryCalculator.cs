using Domain.Entities.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Processses.Payroll
{
    public abstract class BaseSalaryCalculator
    {
        private decimal InssRate => 0.07M;
        private TarifaIR[] tarifaIRs = new TarifaIR[]
        {
            new TarifaIR(){Desde = 0.01M, Hasta=100000,ImpuestoBase = 0, PorcentajeAplicable = 0, SobreExceso = 0},
            new TarifaIR(){Desde = 100000.01M, Hasta = 200000,ImpuestoBase = 0, PorcentajeAplicable = 0.15M, SobreExceso = 100000},
            new TarifaIR(){Desde = 200000.01M, Hasta = 350000,ImpuestoBase = 15000, PorcentajeAplicable = 0.20M, SobreExceso = 200000},
            new TarifaIR(){Desde = 350000.01M, Hasta = 500000,ImpuestoBase = 45000, PorcentajeAplicable = 0.25M, SobreExceso = 350000},
            new TarifaIR(){Desde = 500000.01M, Hasta = 10000000,ImpuestoBase = 87500, PorcentajeAplicable = 0.30M, SobreExceso = 500000},
        };

        public decimal CalculateAnnualSalary(decimal salary)
        {
            return salary * 12;
        }
        public decimal CalculateInss(decimal salary)
        {
            return salary * InssRate;
        }

        public decimal CalculateIr(decimal annualSalary)
        {
            decimal ir = decimal.MinValue;

            foreach (TarifaIR tarifaIR in tarifaIRs)
            {
                if ((annualSalary - tarifaIR.Desde) * (tarifaIR.Hasta - annualSalary) >= 0)
                {
                    ir = ((((annualSalary - tarifaIR.SobreExceso) * tarifaIR.PorcentajeAplicable) + tarifaIR.ImpuestoBase) / 12);
                    break;
                }
            }

            return ir;
        }
    }
}
