using Domain.Entities;
using Domain.Enums;
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
    public partial class Transporte : Form
    {
        public Transporte()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VehiculoLiviano vehiculoLiviano = new VehiculoLiviano("Lexus","LX570",5)
            {
                Transmision = Transmision.Automatica
            };

            VehiculoLiviano vehiculoLiviano1 = new VehiculoLiviano("Lexus", "LX570", Domain.Enums.Transmision.Automatica)
            {
                NumeroPuertas = 3
            };
        }
    }
}
