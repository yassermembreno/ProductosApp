using AppCore.Interfaces;
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
    public partial class FrmOrderView : Form
    {
        public IOrderService OrderService { get; set; }
        public IOrderItemService OrderItemService { get; set; } 
        public IItemService ItemService { get; set; }
        public IProductService productService { get; set; }
        public FrmOrderView()
        {
            InitializeComponent();
        }

        private void FrmOrderView_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FrmOrderView_Load(object sender, EventArgs e)
        {
            dgvOrders.DataSource = OrderService.FindAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmOrder frmOrder = new FrmOrder();
            frmOrder.productService = productService;
            frmOrder.ItemService = ItemService;
            frmOrder.OrderService = OrderService;
            frmOrder.OrderItemService = OrderItemService;

            frmOrder.ShowDialog();
        }
    }
}
