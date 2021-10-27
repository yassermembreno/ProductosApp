using Demos;
using Domain.Entities.Inventories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.FormDemos
{
    public partial class FrmDemos : Form
    {
        private IProductRepository productRepository;
        public FrmDemos(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Generic<string> text = new Generic<string>();

            //text.Field = $"Esto es una cadena";

            //Generic<int> number = new Generic<int>();
            //number.Field = 5;


            //Generic<Producto> product = new Generic<Producto>();

            Producto p = new Producto()
            {
                Id = 1,
                Nombre = "Leche Entera",
                Descripcion = "Presentacion de 1 litro, 3% de grasa",
                InventoryMethod = Domain.Enums.Inventories.InventoryMethod.PEPS,
                UnidadMedida = Domain.Enums.MeasureUnit.Litros
            };

            Print<Order>(new Order() {
                 Id = 1,
                 Date = DateTime.Now,
                 Type = Domain.Enums.Inventories.OrderType.Purchase,
                 Status = Domain.Enums.Inventories.OrderStatus.New,
                 Discount = 0.0M,
                 ShippingCharge = 0.0M,
                 Subtotal = 100.00M            
            });
        }

        private void Print<T>(T obj)
        {
            PropertyInfo[] properties =  obj.GetType().GetProperties();            
            StringBuilder builder = new StringBuilder();
            
            foreach(PropertyInfo info in properties)
            {
                builder.Append($"{info.Name} : {info.GetValue(obj)}\n");                
            }

            MessageBox.Show(builder.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                Id = productRepository.FindAll().Count == 0 ? 1 : productRepository.FindAll().Last().Id + 1,
                Nombre = $"Leche de Soya {(1)}",
                Descripcion = $"0% grasa {(1)}L",
                UnidadMedida = Domain.Enums.MeasureUnit.Litros,
                InventoryMethod = Domain.Enums.Inventories.InventoryMethod.PEPS
            };

            for (int i = 0; i < 10; i++)
            {
                productRepository.Create(p);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ICollection<Producto> productos = productRepository.FindAll(a => a.Nombre.Contains("Leche")).ToHashSet();
            
            dgvProducts.DataSource = productos;
            
        }
    }
}
