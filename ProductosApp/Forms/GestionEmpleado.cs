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
    public partial class GestionEmpleado : Form
    {
        private EmpleadoModel eModel;
        public GestionEmpleado()
        {
            eModel = new EmpleadoModel();
            InitializeComponent();
        }

        private void BtnDocente_Click(object sender, EventArgs e)
        {
            Empleado emp = new Docente(1000, "Pepito Jose", "Perez Soza",
                "001-000000-0000U", 12987.99M)
            {
                CategoriaDocente = Domain.Enums.CategoriaDocente.Titular                
            };

            eModel.Create(emp);
            PrintEmpleado();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            Empleado emp = new Administrativo(3000, "Ana Cecilia", "Conda Urroz",
                "001-000000-0000X", 14900.10M)
            {
                HorasExtras = 20.4f
            };

            eModel.Create(emp);
            PrintEmpleado();
        }

        private void PrintEmpleado()
        {
            Empleado[] empleados = eModel.GetEmpleados();

            if(empleados == null)
            {
                rtbEmpleados.Text = "No hay elementos para mostrar.";
                return;
            }
            rtbEmpleados.Text = "";
            rtbEmpleados.Text = string.Format("{0,-10} {1,-20} {2,-20} {3,-16} {4,-10} {5,-10} \n",
                "Codigo","Nombres","Apellidos","Cedula","Salario","Propiedad");
            foreach (Empleado emp in empleados)
            {
                rtbEmpleados.AppendText(emp.GetEmpleadoAsString());
            }
        }
    }
}
