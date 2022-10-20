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
    public partial class frmOrders : Form
    {
        public MemberObject member;
        public frmOrders(MemberObject member)
        {
            this.member = member;
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            if(member.Email == "admin@fstore.com")
            {
                IOrderRepository orderRepository = new OrderRepository();
                List<OrderObject> orders = orderRepository.GetOrders();
                gvOrder.DataSource = orders;
                btnReport.Enabled = true ;
                
            }
            else
            {
                IOrderRepository orderRepository = new OrderRepository();
                List<OrderObject> orders = orderRepository.GetOrdersByMemberId(member.MemberId);
                gvOrder.DataSource = orders;
                btnReport.Visible = false;
            }
            btnViewDetail.Enabled = false;
            gvOrder.ClearSelection();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {

            if (gvOrder.SelectedRows.Count > 0)
            {
                int selectedIndex = gvOrder.SelectedRows[0].Index;
                DataGridViewRow selectedRow = gvOrder.Rows[selectedIndex];
                int orderId = Convert.ToInt32(selectedRow.Cells["OrderId"].Value.ToString());
                frmOrderDetail frmOrderDetail = new frmOrderDetail(orderId);
                frmOrderDetail.ShowDialog();

            }
        }

        private void gvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnViewDetail.Enabled = true;

        }

        private void gvOrder_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.ShowDialog();

        }
    }
}
