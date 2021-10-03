using Domain.Entities.Activos;
using Domain.Enums.Activos;
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
    public partial class FrmActivoFijo : Form
    {
        public ActivoFijoModel ActivoFijoModel { get; set; }
        public FrmActivoFijo()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int id, tipoActivoFijo;
            string codigo, nombre, descripcion;
            decimal valor;
            DateTime fecha;

            id = ActivoFijoModel.GetLastActivoFijoId() + 1;
            tipoActivoFijo = cmbTipoActivo.SelectedIndex;
            codigo = txtCodigo.Text;
            nombre = txtNombre.Text;
            descripcion = txtDescripcion.Text;
            valor = nudValor.Value;
            fecha = dtpAdquisicion.Value;

            ActivoFijo activo = new ActivoFijo()
            {
                Id = id,
                CodigoActivo = codigo,
                NombreActivo = nombre,
                Descripcion = descripcion,
                FechaAdquisicion = fecha,
                ValorActivo = valor,
                TipoActivoFijo = (TipoActivoFijo)tipoActivoFijo,
                MetodoDepreciacion = (MetodoDepreciacion) cmbMetodo.SelectedIndex
            };

            ActivoFijoModel.Create(activo);

            Dispose();
         }

        private void FrmActivoFijo_Load(object sender, EventArgs e)
        {
            cmbTipoActivo.Items.AddRange(Enum.GetValues(typeof(TipoActivoFijo)).Cast<object>().ToArray());
            cmbMetodo.Items.AddRange(Enum.GetValues(typeof(MetodoDepreciacion)).Cast<object>().ToArray());
        }
    }
}
