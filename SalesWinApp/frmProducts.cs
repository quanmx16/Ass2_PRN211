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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            IProductRepository productRepository = new ProductRepository();
            List<ProductObject> products = productRepository.GetProducts();
            gvProduct.DataSource = products;
            gvProduct.ClearSelection();
            this.btnUpdate.Enabled = false;
            this.rdById.Checked = true;
            this.btnSearch.Enabled = false;
            this.txtSearch.Text = "";
            btnLoadAll.Enabled = false;
        }

        private void gvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvProduct.SelectedRows.Count > 0)
            {
                this.btnUpdate.Enabled = true;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (gvProduct.SelectedRows.Count > 0)
            {
                int index = gvProduct.SelectedRows[0].Index;
                int productId = Convert.ToInt32(gvProduct.Rows[index].Cells["ProductId"].Value);
                IProductRepository productRepository = new ProductRepository();
                ProductObject updatedProduct = productRepository.GetProductById(productId);
                frmUpdateProduct frmUpdateProduct = new frmUpdateProduct(updatedProduct);
                frmUpdateProduct.ShowDialog();
                frmProducts_Load(sender, e);

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateProduct frmCreateProduct = new frmCreateProduct();
            frmCreateProduct.ShowDialog();
            frmProducts_Load(sender, e);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            IProductRepository productRepository = new ProductRepository();

            if (rdById.Checked)
            {
                try
                {
                    int productId = Convert.ToInt32(txtSearch.Text.Trim());
                    List<ProductObject> validProducts = new List<ProductObject>();
                    validProducts.Add(productRepository.GetProductById(productId));
                    gvProduct.DataSource = validProducts;
                    gvProduct.ClearSelection();



                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Id must be a number!");
                    this.ActiveControl = txtSearch;
                }
            }
            else
            {
                List<ProductObject> products = productRepository.GetProducts();
                List<ProductObject> validProducts = new List<ProductObject>();
                foreach (ProductObject product in products)
                {
                    if (product.ProductName.Contains(txtSearch.Text))
                    {
                        validProducts.Add(product);
                    }
                }
                gvProduct.DataSource = validProducts;
                gvProduct.ClearSelection();

            }
            btnLoadAll.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                btnSearch.Enabled = true;
            }
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            frmProducts_Load(sender, e);
            
        }
    }
}
