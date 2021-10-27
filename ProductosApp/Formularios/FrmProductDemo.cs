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
    public partial class FrmProductDemo : Form
    {
        private IProductRepository productRepository;

        public FrmProductDemo(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            InitializeComponent();
        }

        private void PopulateProducts()
        {
            Producto p1 = new Producto()
            {
                Id = productRepository.FindAll().Count == 0 ? 1 : productRepository.FindAll().Last().Id + 1,
                Nombre = "Leche de Soya",
                Descripcion = "0% de grasa, presentacion de 1 litro",
                Existencia = 15,
                FechaVencimiento = new DateTime(2021, 12, 22),
                Precio = 35,
                UnidadMedida = Domain.Enums.UnidadMedida.Litros
            };
            productRepository.Create(p1);

            Producto p2 = new Producto()
            {
                Id = productRepository.FindAll().Count == 0 ? 1 : productRepository.FindAll().Last().Id + 1,
                Nombre = "Queso de soya",
                Descripcion = "0% de grasa, presentacion de 1 libra",
                Existencia = 25,
                FechaVencimiento = new DateTime(2022, 04, 21),
                Precio = 16,
                UnidadMedida = Domain.Enums.UnidadMedida.Libras
            };
            productRepository.Create(p2);
            Producto p3 = new Producto()
            {
                Id = productRepository.FindAll().Count == 0 ? 1 : productRepository.FindAll().Last().Id + 1,
                Nombre = "Carne de soya",
                Descripcion = "presentacion de 1 libra",
                Existencia = 10,
                FechaVencimiento = new DateTime(2021, 11, 4),
                Precio = 35,
                UnidadMedida = Domain.Enums.UnidadMedida.Libras
            };
            productRepository.Create(p3);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PopulateProducts();
            //Producto p = productRepository.FindAny(a => a.Id == 2);
            //List<Producto> list = new List<Producto>();
            //list.Add(p);
            //dataGridView1.DataSource = list;
            List<Producto> list = productRepository.FindAll(a => a.UnidadMedida == Domain.Enums.UnidadMedida.Libras).ToList();
            dataGridView1.DataSource = list;
        }
    }
}
