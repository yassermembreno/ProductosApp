using Domain.Entities.Activos;
using Infraestructure.ActivosFijos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Forms.ActivoFijos
{
    public partial class FrmGestionActivoFijo : Form
    {
        private ActivoFijoModel activoFijoModel;
        public FrmGestionActivoFijo()
        {
            activoFijoModel = new ActivoFijoModel();
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmActivoFijo frmActivoFijo = new FrmActivoFijo();
            frmActivoFijo.ActivoFijoModel = activoFijoModel;
            frmActivoFijo.ShowDialog();
            PrintActivos();

        }

        private void PrintActivos()
        {
            ActivoFijo[] activoFijos = activoFijoModel.GetAll();
            if (activoFijos == null)
            {
                rtbDepre.Text = $"Lista de activos vacia.";
                return;
            }
            string text = string.Format("{0,5:d} {1,-20} {2,-15} {3,5:f} {4,-30:d} {5,4:d} \n", "Id", "Codigo", "Nombre", "Valor", "Fecha Adquisicion", "Tipo Activo");
            rtbDepre.Text = text;
            ProcesoDepreciacion procesoDepreciacion = new ProcesoDepreciacion();
            foreach (ActivoFijo af in activoFijos)
            {
                rtbDepre.AppendText(af.ToString());
                rtbDepre.AppendText($"{Environment.NewLine}");
                int i = 1;
                foreach(decimal d in procesoDepreciacion.Depreciar(af))
                {
                    rtbDepre.AppendText($"{i++} =>  {d} \n");
                }
            }
        }
    }
}
