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

namespace ProductosApp.Formularios
{
    public partial class FrmGestionEmpleados : Form
    {
        private EmpleadoModel empleadoModel;
        public FrmGestionEmpleados()
        {
            empleadoModel = new EmpleadoModel();
            InitializeComponent();
        }

        private void BtnDoc_Click(object sender, EventArgs e)
        {
            Empleado emp = new Docente(1000, "001-000000-0000U", "Pepito Jose",
                "Perez Soza", 23786.98M, DateTime.Now)
            {
                CategoriaDocente = Domain.Enums.CategoriaDocente.Titular,
                Id = empleadoModel.GetLastEmpleadoId() + 1
            };

            empleadoModel.Create(emp);
            PrintEmpleado();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            Empleado emp = new Administrativo(3000, "001-000000-0000P", "Ana Cecilia",
               "Conda Jimenez", 337860.00M, DateTime.Now)
            {
                HorasExtras = 23.5f,
                Id = empleadoModel.GetLastEmpleadoId() + 1
            };

            empleadoModel.Create(emp);
            PrintEmpleado();
        }

        private void PrintEmpleado()
        {
            Empleado[] empleados = empleadoModel.GetEmpleados();
            if (empleados == null)
            {
                richTextBox1.Text = "No hay elementos a mostrar.";
                return;
            }
            richTextBox1.Text = "";
            foreach(Empleado e in empleados)
            {
                richTextBox1.AppendText(e.GetEmpleadoAsString());
            }
        }
    }
}
