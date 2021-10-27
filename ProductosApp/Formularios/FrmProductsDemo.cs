using Domain.Entities;
using Domain.Interfaces;
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
    public partial class FrmProductsDemo : Form
    {
        private IProductRepository productRepository;
        public FrmProductsDemo(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            List<Producto> productos = new List<Producto>()
            {
                new Producto()
                {
                    Id = 1,//productRepository.FindAll().Count == 0 ? 1 : productRepository.FindAll().Last().Id + 1,
                    Nombre = "Leche de Soya",
                    Descripcion = "0% grasa 1 Litro",
                    UnidadMedida = Domain.Enums.UnidadMedida.Litros,
                    Precio = 50.00M,
                    Existencia = 12,
                    FechaVencimiento = new DateTime(2021,12,19)
                },
                new Producto()
                {
                    Id = 2,//productRepository.FindAll().Count == 0 ? 1 : productRepository.FindAll().Last().Id + 1,
                    Nombre = "Queso de Soya",
                    Descripcion = "0% grasa 1 Libras",
                    UnidadMedida = Domain.Enums.UnidadMedida.Libras,
                    Precio = 70.00M,
                    Existencia = 22,
                    FechaVencimiento = new DateTime(2021,12,01)
                },
                new Producto()
                {
                    Id = 3,//productRepository.FindAll().Count == 0 ? 1 : productRepository.FindAll().Last().Id + 1,
                    Nombre = "Carne de Soya",
                    Descripcion = "0% grasa 1 Libra",
                    UnidadMedida = Domain.Enums.UnidadMedida.Libras,
                    Precio = 90.00M,
                    Existencia = 20,
                    FechaVencimiento = new DateTime(2021,12,04)
                }
            };

            productos.ForEach(p => productRepository.Create(p));

            //Producto pr = productRepository.FindAny(a => a.Id == 2);
            //List<Producto> view = new List<Producto>();
            //view.Add(pr);

            List<Producto> view = productRepository
                .FindAll(a => a.FechaVencimiento <= new DateTime(2021, 12, 25)).ToList();
            dataGridView1.DataSource = view;

        }
    }
}
