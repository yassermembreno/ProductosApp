using AppCore.Filter.OrderItems;
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
        private Form activeForm;
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
            PopulateOrder();
            //foreach(Item item in itemService.FindAll())
            //{
            //    richTextBox1.AppendText($"item: {item.Id} -  {item.Producto.Nombre} - {item.Producto.Descripcion}\n");                
            //}

            //richTextBox1.AppendText($"Final Inventory: {peps.CalculateFinalInventory(itemService.FindAll())}\n");
            //richTextBox1.AppendText($"Sales Cost: {peps.CalculateSalesCost(orderItemService.FindAll())}\n");

            PrintPEPS();

        }

        private void PopulateProduct()
        {
            Producto p = new Producto()
            {
                Id = productService.GetLastId() + 1,
                Nombre = "Coca-Cola",
                Descripcion = "Presentacion de 1.5 litros",
                InventoryMethod = Domain.Enums.Inventories.InventoryMethod.PEPS,
                UnidadMedida = Domain.Enums.MeasureUnit.Unidades
            };

            productService.Create(p);

            Producto p1 = new Producto()
            {
                Id = productService.GetLastId() + 1,
                Nombre = "Fanta Naranja",
                Descripcion = "Presentacion de 1.5 litros",
                InventoryMethod = Domain.Enums.Inventories.InventoryMethod.PEPS,
                UnidadMedida = Domain.Enums.MeasureUnit.Unidades
            };

            productService.Create(p1);

            Producto p2 = new Producto()
            {
                Id = productService.GetLastId() + 1,
                Nombre = "Coca-Cola",
                Descripcion = "Presentacion de 2.0 litros",
                InventoryMethod = Domain.Enums.Inventories.InventoryMethod.PEPS,
                UnidadMedida = Domain.Enums.MeasureUnit.Unidades
            };
            
            productService.Create(p2);

            Producto p3 = new Producto()
            {
                Id = productService.GetLastId() + 1,
                Nombre = "Leche",
                Descripcion = "Lala 1 litro",
                InventoryMethod = Domain.Enums.Inventories.InventoryMethod.PEPS,
                UnidadMedida = Domain.Enums.MeasureUnit.Litros
            };

            productService.Create(p3);

        }

        private void PopulateItems()
        {
            Item item = new Item()
            {
                Id = itemService.GetLastId() + 1,
                SKU = "1-CC",
                Brand = "Coca-Cola",
                //Available = 10,
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
                Id = itemService.GetLastId() + 1,
                SKU = "1-FN",
                Brand = "Coca-Cola",
                //Available = 15,
                Cost = 41.50M,
                Price = 47.00M,
                Quantity = 20,
                Sold = 5,
                MaximumRetailPrice = 52.00M,
                Defective = 0,
                Discount = 1.00M,
                ExpirationDate = new DateTime(2022, 02, 07),
                Producto = productService.GetProductoById(2)
            };

            itemService.Create(item2);
        }

        private void PopulateOrder()
        {
            Order order = new Order()
            {
                Id = orderService.GetLastId() + 1,
                Type = Domain.Enums.Inventories.OrderType.Purchase,
                Date = new DateTime(2021, 10, 07),
                Discount = 0,
                ShippingCharge = 0,
                Status = Domain.Enums.Inventories.OrderStatus.Delivered,
                Subtotal = 1000M                
            };

            orderService.Create(order);

            foreach(Item item in itemService.FindAll())
            {
                OrderItem orderItem = new OrderItem(item.Producto, item, order)
                {
                    Id = orderItemService.GetLastId() + 1,
                    SKU = item.SKU,
                    Quantity = item.Quantity,
                    Cost = item.Cost,
                    Discount = 0,
                    Price = item.Price
                };

                orderItemService.Create(orderItem);
            }


            Order salesOrder = new Order()
            {
                Id = orderService.GetLastId() + 1,
                Type = Domain.Enums.Inventories.OrderType.Sales,
                Date = new DateTime(2021, 10, 17),
                Discount = 0,
                ShippingCharge = 0,
                Status = Domain.Enums.Inventories.OrderStatus.Paid,
                Subtotal = 1000M
            };

            orderService.Create(salesOrder);

            foreach (Item item in itemService.FindAll())
            {
                OrderItem orderItem = new OrderItem(item.Producto, item, salesOrder)
                {
                    Id = orderItemService.GetLastId() + 1,
                    SKU = item.SKU,
                    Quantity = 3,
                    Cost = item.Cost,
                    Discount = 0,
                    Price = item.MaximumRetailPrice
                };

                orderItemService.Create(orderItem);
            }
        }

        private void PrintPEPS()
        {
            OrderItem[] orderItems = orderItemService.FindAll();

            Array.Sort(orderItems, new OrderItemSortByOrderDate());

            //richTextBox1.AppendText($"Fecha \t\tDescripcion \t\tUnidades Costo Inventario Final Costo Venta\n");
            //foreach(OrderItem orderItem in orderItems)
            //{
            //    richTextBox1.AppendText($"{orderItem.Order.Date} \t\t{orderItem.Order.Type} \t\t{orderItem.Quantity} {orderItem.Cost} {(orderItem.Quantity * orderItem.Cost)}\n");
            //}
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FrmOrderView frmOrderView = new FrmOrderView();
            frmOrderView.OrderService = orderService;
            frmOrderView.ItemService = itemService;
            frmOrderView.productService = productService;
            frmOrderView.OrderItemService = orderItemService;
            ShowActiveForm(frmOrderView);
        }

        private void ShowActiveForm(Form form)
        {
            activeForm = form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            pnlContent.Controls.Add(form);
            activeForm.Show();
        }
    }
}
