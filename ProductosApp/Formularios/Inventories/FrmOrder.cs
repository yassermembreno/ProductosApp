using AppCore.Interfaces;
using Domain.Entities.Inventories;
using Domain.Enums.Inventories;
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
    public partial class FrmOrder : Form
    {
        public IOrderService OrderService { get; set; }
        public IOrderItemService OrderItemService { get; set; }
        public IItemService ItemService { get; set; }
        public IProductService productService { get; set; }

        private int selectedProductIndex = -1;
        private int selectedOrderTypeIndex = -1;        
        private ComboBox cmbProduct;

        private OrderItem[] orderItems;
        private Item[] items;

        public FrmOrder()
        {
            InitializeComponent();
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            cmbOrderType.Items.AddRange(Enum.GetValues(typeof(OrderType)).Cast<object>().ToArray());
            DataGridViewComboBoxColumn dgvcmbProduct = (DataGridViewComboBoxColumn)dgvOrderItem.Columns["ProductCol"];           
            dgvcmbProduct.Items.AddRange(productService.FindAll().Select(p => $"{p.Nombre} - {p.Descripcion}").ToList().ToArray());//Expresion lambda + LinQ
            
        }

        private void dgvOrderItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedOrderTypeIndex = cmbOrderType.SelectedIndex;

            if (selectedOrderTypeIndex == 0 && e.ColumnIndex == 0 && selectedProductIndex >= 0)
            {               
                Producto p = productService.FindAll()[selectedProductIndex];
                Item item = new Item()
                {
                    Id = ItemService.GetLastId() + 1,
                    Brand = "Coca-cola",
                    SKU = $"2CC-00{ItemService.GetLastId() + 1}",
                    Producto = p,
                    Cost = 0,
                    Defective = 0,
                    Discount = 0,
                    ExpirationDate = new DateTime(2022,01,02),
                    MaximumRetailPrice = 0,
                    Price = 0,
                    Quantity = 0,
                    Sold = 0
                };

                ItemService.Add(item, ref items);
            }
        }

        private void dgvOrderItem_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {           
            cmbProduct = e.Control as ComboBox;            
        }

        private void dgvOrderItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(cmbProduct == null)
            {
                return;
            }

            selectedProductIndex = cmbProduct.SelectedIndex;
        }
    }
}
