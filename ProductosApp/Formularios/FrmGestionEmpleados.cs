using AppCore.Factories;
using AppCore.Interfaces;
using AppCore.Processses;
using AppCore.Processses.Payroll;
using Domain.Entities.Empleados;
using Infraestructure.Empleados;
using System;
using System.Windows.Forms;

namespace ProductosApp.Formularios
{
    public partial class FrmGestionEmpleados : Form
    {
        private IEmpleadoService empleadoService; // Inversion of Control        
        public FrmGestionEmpleados(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;            
            InitializeComponent();
        }

        private void BtnDoc_Click(object sender, EventArgs e)
        {
            Empleado emp = new Docente(1000, "001-000000-0000U", "Pepito Jose",
                "Perez Soza", 23786.98M, DateTime.Now)
            {
                CategoriaDocente = Domain.Enums.CategoriaDocente.Titular,
                Id = empleadoService.GetLastEmpleadoId() + 1
            };

            empleadoService.Create(emp);
            PrintEmpleado();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            Empleado emp = new Administrativo(3000, "001-000000-0000P", "Ana Cecilia",
               "Conda Jimenez", 337860.00M, DateTime.Now)
            {
                HorasExtras = 23.5f,
                Id = empleadoService.GetLastEmpleadoId() + 1
            };

            empleadoService.Create(emp);
            PrintEmpleado();
        }

        private void PrintEmpleado()
        {
            Empleado[] empleados = empleadoService.FindAll();
            if (empleados == null)
            {
                richTextBox1.Text = "No hay elementos a mostrar.";
                return;
            }
            richTextBox1.Text = "";
            foreach(Empleado e in empleados)
            {
                richTextBox1.AppendText(e.GetEmpleadoAsString());
                
                richTextBox1.AppendText($"Salario neto: {SalaryCalculatorFactory.CreateInstance(e).CalculateSalary(e)} \n");
            }
        }
    }
}
