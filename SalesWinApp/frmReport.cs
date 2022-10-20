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
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            txtNoOrders.Enabled = false;
            txtSumOfFreight.Enabled = false;
            txtTotal.Enabled = false;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime from = DateTime.Parse(dateTimeFrom.Text);
            DateTime end = DateTime.Parse(dateTimeEnd.Text);
            if (from > end)
            {
                MessageBox.Show("End date must be greater than from date!");
            }
            else
            {
                IOrderRepository orderRepository = new OrderRepository();
                IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
                List<OrderObject> orders = orderRepository.GetOrders();

                List<OrderDetailObject> validOrderDetails = new List<OrderDetailObject>();
                double total = 0;
                double sumOfFreight = 0;
                int numberOfOrder = 0;
                foreach (OrderObject order in orders)
                {
                    if (order.OrderDate >= from && order.OrderDate <= end)
                    {
                        numberOfOrder++;
                        sumOfFreight += order.Freight.ToDouble();
                        List<OrderDetailObject> orderDetails = orderDetailRepository.GetOrderDetailByOrderId(order.OrderId);
                        foreach (OrderDetailObject orderDetail in orderDetails)
                        {
                            validOrderDetails.Add(orderDetail);
                        }
                    }
                }

                foreach (OrderDetailObject order in validOrderDetails)
                {
                    total += order.UnitPrice.ToDouble() * order.Quantity * (1 - order.Discount);
                    System.Diagnostics.Debug.WriteLine($"Total:{total} \n");
                }


                txtNoOrders.Text = numberOfOrder.ToString();
                txtSumOfFreight.Text = sumOfFreight.ToString();
                txtTotal.Text = total.ToString();


            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
