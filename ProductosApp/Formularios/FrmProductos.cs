using AppCore.Interfaces;
using Domain.Enums;
using Infraestructure.Productos;
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
    public partial class FrmProductos : Form
    {
        private IProductoService productoService;
        public FrmProductos(IProductoService productoService)
        {
            this.productoService = productoService;
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.Items.AddRange(Enum.GetValues(typeof(UnidadMedida))
                                              .Cast<object>()
                                              .ToArray()
                                          );

        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            FrmProducto frmProducto = new FrmProducto();
            frmProducto.PModel = productoService;
            frmProducto.ShowDialog();

            rtbProductView.Text = productoService.GetProductosAsJson();
        }

        private void CmbFinderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFinderType.SelectedIndex)
            {
                case 0:
                    txtFinder.Visible = true;
                    cmbMeasureUnit.Visible = false;
                    break;
                case 3:
                    cmbMeasureUnit.Visible = true;
                    txtFinder.Visible = false;
                    break;                
            }
        }
    }
}
