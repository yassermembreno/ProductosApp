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
            //DataGridViewComboBoxColumn dgvcmbProduct = (DataGridViewComboBoxColumn)dgvOrderItem.Columns["ProductCol"];           
            //dgvcmbProduct.Items.AddRange(productService.FindAll().Select(p => $"{p.Nombre} - {p.Descripcion}").ToList().ToArray());//Expresion lambda + LinQ
            dgvOrderItem.Rows.Clear();
            dgvProducts.DataSource = productService.FindAll();
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

        private void ShowMessageError(string message)
        {
            MessageBox.Show(this, message, "Mensaje de Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            int id = (int) dgvProducts.Rows[dgvProducts.CurrentCell.RowIndex].Cells[0].Value;
            Producto p = productService.GetProductoById(id);
            Item item = ItemService.FindByProductId(p.Id).Last();
            OrderItem orderItem = new OrderItem(p, item, null )
            {
                Id = OrderItemService.GetLastId(),
                Cost = 0,
                Price = selectedOrderTypeIndex == 1 ? item.MaximumRetailPrice : 0,
                Discount = 0,
                Quantity = 0,
                SKU = item.SKU
            };

            OrderItem temp = orderItems?.Where(o => o.Producto.Id == orderItem.Producto.Id)?.FirstOrDefault();
            if(temp != null)
            {
                ShowMessageError($"Error, el producto con Id {p.Id} ya ha sido agregado.");
                return;
            }

            OrderItemService.Add(orderItem, ref orderItems);

            DataGridViewRow dgvOrderRow = (DataGridViewRow) dgvOrderItem.Rows[0].Clone();

            dgvOrderRow.Cells[0].Value = $"{orderItem.Producto.Nombre} - {orderItem.Producto.Descripcion}";
            dgvOrderRow.Cells[1].Value = 0;
            dgvOrderRow.Cells[2].Value = selectedOrderTypeIndex == 1 ? orderItem.Item.MaximumRetailPrice : 0;
            dgvOrderRow.Cells[3].Value = Math.Round(CalculateSubtotal((int)dgvOrderRow.Cells[1].Value , (decimal)dgvOrderRow.Cells[2].Value),2);
            
            dgvOrderItem.Rows.Add(dgvOrderRow);
        }

        private decimal CalculateSubtotal(int q, decimal price)
        {
            return Math.Round(q * price);
        }

        private void dgvOrderItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            decimal subtotal = 0;
            decimal iva;
            decimal discount = 0;
            decimal total;

            dgvOrderItem.Rows[e.RowIndex].Cells[3].Value = Decimal.Round(CalculateSubtotal(int.Parse(dgvOrderItem.Rows[e.RowIndex].Cells[1].Value.ToString()),
                                                                                       decimal.Parse(dgvOrderItem.Rows[e.RowIndex].Cells[2].Value.ToString())), 2);
            foreach(DataGridViewRow row in dgvOrderItem.Rows)
            {
                if(row.Cells[3].Value == null)
                {
                    continue;
                }
                subtotal += decimal.Parse(row.Cells[3].Value.ToString());
            }

            iva = subtotal * 0.15M;
            total = subtotal + iva;
            discount = subtotal * 0.10M;

            txtSubtotal.Text = subtotal.ToString();
            txtIva.Text = iva.ToString();
            txtDiscount.Text = discount.ToString();
            txtTotal.Text = total.ToString();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    dgvProducts.DataSource = productService.FindAll();
                    return;
                }

                DataTable dt = ConvertToDataTable();
                dt.DefaultView.RowFilter = string.Format("Nombre LIKE '*{0}*' ", txtSearch.Text);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgvProducts.DataSource = bs;
            }
        }

        private DataTable ConvertToDataTable()
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgvProducts.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            return dt;
        }
    }
}
