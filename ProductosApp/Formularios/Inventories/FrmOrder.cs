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
                
        private int selectedOrderTypeIndex = -1;                

        private OrderItem[] orderItems;        
        
        public FrmOrder()
        {
            InitializeComponent();
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            cmbOrderType.Items.AddRange(Enum.GetValues(typeof(OrderType)).Cast<object>().ToArray());            
            dgvOrderItem.Rows.Clear();
            dgvProducts.DataSource = productService.FindAll();
        }        

        private void ShowMessageError(string message)
        {
            MessageBox.Show(this, message, "Mensaje de Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count == 0)
            {
                return;
            }

            int id = (int) dgvProducts.Rows[dgvProducts.CurrentRow.Index].Cells[0].Value;
            Producto p = productService.GetProductoById(id);
            if(p == null)
            {
                ShowMessageError($"Error, no se pudo obtener el Producto con id: {id}.");
                return;
            }

            Item item = ItemService.FindByProductId(p.Id)?.Last();
            if (item == null)
            {
                ShowMessageError($"Error, no se pudo obtener el Item del Producto: {p.Nombre}.");
                return;
            }

            OrderItem orderItem = new OrderItem(p, item, null )
            {
                Id = OrderItemService.GetLastId(),
                Cost = 0,
                Price = selectedOrderTypeIndex == 1 ? item.MaximumRetailPrice : 0,
                Discount = 0,
                Quantity = 0,
                SKU = item.SKU
            };

            OrderItem temp = orderItems?.Where(o => o.Producto.Id == orderItem.Producto.Id)?
                                        .FirstOrDefault();
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
            dgvOrderRow.Cells[3].Value = decimal.Round(CalculateSubtotal((int)dgvOrderRow.Cells[1].Value , (decimal)dgvOrderRow.Cells[2].Value),2);
            
            dgvOrderItem.Rows.Add(dgvOrderRow);
        }

        private decimal CalculateSubtotal(int q, decimal price)
        {
            return Math.Round(q * price,2);
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
            int available = 0;
            selectedOrderTypeIndex = cmbOrderType.SelectedIndex;

            if (selectedOrderTypeIndex < 0)
            {
                dgvOrderItem.Rows[e.RowIndex].Cells[1].Value = 0;
                return;
            }

            if(e.ColumnIndex == 1 && selectedOrderTypeIndex == 1)
            {
                Item[] items = ItemService.FindByProductId(orderItems[e.RowIndex].Producto.Id);
                if(items == null)
                {
                    ShowMessageError($"Error, ese producto no esta disponible.");
                    return;
                }
                available = items.Select(i => i.Available).Sum();
                int q = int.Parse(dgvOrderItem.Rows[e.RowIndex].Cells[1].Value.ToString());

                if(q > available)
                {
                    ShowMessageError($"Error, la cantidad {q} sobrepasa lo disponible {available}.");
                    dgvOrderItem.Rows[e.RowIndex].Cells[1].Value = available;
                    return;
                }
            }
            
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
            discount = subtotal * 0.10M;
            total = subtotal + iva - discount;

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
                dt.DefaultView.RowFilter = string.Format("Nombre LIKE '*{0}*' OR UnidadMedida LIKE '*{0}*' OR Id = '{0}'", txtSearch.Text);
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
