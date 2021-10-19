using AppCore.Interfaces;
using Domain.Entities.Inventories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Formularios.Inventories
{
    public partial class FrmInventoryManagement : Form
    {
        private IProductService productService;
        private IOrderService orderService;
        private IOrderItemService orderItemService;
        private IItemService itemService;
        private IInventoryCalculator peps;
        public FrmInventoryManagement()
        {
            InitializeComponent();
        }

        public FrmInventoryManagement(IProductService productService, IOrderService orderService, IOrderItemService orderItemService, IItemService itemService, IInventoryCalculator peps)
        {            
            this.productService = productService;
            this.orderService = orderService;
            this.orderItemService = orderItemService;
            this.itemService = itemService;
            this.peps = peps;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateProduct();
            PopulateItems();

            foreach(Item item in itemService.FindAll())
            {
                richTextBox1.AppendText($"item: {item.Producto.Nombre} ,{item.Producto.Descripcion}\n");                
            }
            richTextBox1.AppendText($"Final Inventory: {peps.CalculateFinalInventory(itemService.FindAll())}");
        }

        private void PopulateProduct()
        {
            Producto p = new Producto()
            {
                Id = productService.GetLastProductoId() + 1,
                Nombre = "Coca-Cola",
                Descripcion = "Presentacion de 1.5 litros",
                InventoryMethod = Domain.Enums.Inventories.InventoryMethod.PEPs,
                UnidadMedida = Domain.Enums.MeasureUnit.Unidades
            };

            productService.Create(p);
        }

        private void PopulateItems()
        {
            Item item = new Item()
            {
                Id = 1,
                SKU = "1-CC",
                Brand = "Coca-Cola",
                Available = 10,
                Cost = 39.50M,
                Price = 45.00M,
                Quantity = 30,
                Sold = 20,
                MaximumRetailPrice = 50.00M,
                Defective = 0,
                Discount = 1.00M,
                ExpirationDate = new DateTime(2022,01,07),
                Producto = productService.GetProductoById(1)
            };

            itemService.Create(item);

            Item item2 = new Item()
            {
                Id = 1,
                SKU = "1-CC",
                Brand = "Coca-Cola",
                Available = 15,
                Cost = 41.50M,
                Price = 47.00M,
                Quantity = 20,
                Sold = 5,
                MaximumRetailPrice = 52.00M,
                Defective = 0,
                Discount = 1.00M,
                ExpirationDate = new DateTime(2022, 02, 07),
                Producto = productService.GetProductoById(1)
            };

            itemService.Create(item2);
        }


    }
}
