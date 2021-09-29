using Domain.Entities.Empleados;
using Infraestructure.Empleados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Forms
{
    public partial class FrmGestionEmpleado : Form
    {
        private EmpleadoModel empleadoModel;
        public FrmGestionEmpleado()
        {
            empleadoModel = new EmpleadoModel();
            InitializeComponent();
        }

        private void BtnDoc_Click(object sender, EventArgs e)
        {
            Empleado emp = new Docente()
            {
                Id = empleadoModel.GetLastEmpleadoId() + 1,
                Codigo = 1000,
                Cedula = "001-000000-0000U",
                Nombres = "Pepito Jose",
                Apellidos = "Perez Soza",
                Salario = 22000M,
                FechaContratacion = DateTime.Now,
                CategoriaDocente = Domain.Enums.CategoriaDocente.Titular
            };

            empleadoModel.Create(emp);
            PrintEmpleado();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            Empleado emp = new Administrativo()
            {
                Id = empleadoModel.GetLastEmpleadoId() + 1,
                Codigo = 1000,
                Cedula = "001-000000-0000X",
                Nombres = "Ana Cecilia",
                Apellidos = "Conda Jimenez",
                Salario = 24000.99M,
                FechaContratacion = DateTime.Now,
                HorasExtras = 10.5f
            };

            empleadoModel.Create(emp);
            PrintEmpleado();
        }

        private void PrintEmpleado()
        {
            Empleado[] empleados = empleadoModel.GetEmpleados();

            if(empleados == null)
            {
                rtbEmpleado.Text = "No hay elementos a mostrar.";
                return;
            }

            rtbEmpleado.Text = "";

            foreach(Empleado e in empleados)
            {
                rtbEmpleado.AppendText(e.GetEmpleadoAsString());
            }
        }
    }
}
