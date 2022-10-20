using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmOrderDetail : Form
    {
        public int OrderId;
        public frmOrderDetail(int orderId)
        {
            InitializeComponent();
            OrderId = orderId;
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {

            IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
            List<OrderDetailObject> orderDetailObjects = orderDetailRepository.GetOrderDetailByOrderId(OrderId);
            gvOrderDetail.DataSource = orderDetailObjects;
            double total = 0;
            foreach (OrderDetailObject orderDetailObject in orderDetailObjects)
            {
                total += orderDetailObject.UnitPrice.ToDouble() * orderDetailObject.Quantity * (1 - orderDetailObject.Discount);
            }
            txtTotal.Text = Math.Round(total, 4).ToString();

            gvOrderDetail.ClearSelection();
        }

        private void gvOrderDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
