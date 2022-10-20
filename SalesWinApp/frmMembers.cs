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
    public partial class frmMembers : Form
    {
        MemberObject loggedInMember = null;
        public frmMembers(MemberObject loggedInMember)
        {
            this.loggedInMember = loggedInMember;
            InitializeComponent();
        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            txtMemberId.Enabled = false;
            txtEmail.Enabled = false;
            txtCompany.Enabled = false;
            txtCity.Enabled = false;
            txtCountry.Enabled = false;

            if (loggedInMember.Email == ("admin@fstore.com"))
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnViewOrder.Visible = false;

                txtMemberId.Text = "";
                txtEmail.Text = "";
                txtCompany.Text = "";
                txtCity.Text = "";
                txtCountry.Text = "";
                IMemberRepository memberRepository = new MemberRepository();
                List<MemberObject> members = memberRepository.GetMembers();
                foreach (MemberObject member in members)
                {
                    if (member.Email == "admin@fstore.com")
                    {
                        members.Remove(member);
                        break;
                    }
                }
                gvMember.DataSource = members;
                gvMember.ClearSelection();

            }
            else
            {
                btnCreate.Visible = false;
                btnDelete.Visible = false;
                btnOrder.Visible = false;
                btnProduct.Visible = false;
                gvMember.Visible = false;
                txtMemberId.Text = loggedInMember.MemberId.ToString();
                txtEmail.Text = loggedInMember.Email.ToString();
                txtCompany.Text = loggedInMember.CompanyName.ToString();
                txtCity.Text = loggedInMember.City.ToString();
                txtCountry.Text = loggedInMember.Country.ToString();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int memberId = Convert.ToInt32(txtMemberId.Text);
            IMemberRepository memberRepository = new MemberRepository();
            MemberObject member = memberRepository.GetMemberById(memberId);
            frmUpdateMember frmUpdateMember = new frmUpdateMember(member);
            frmUpdateMember.ShowDialog();
            if (loggedInMember.Email != ("admin@fstore.com"))
            {
                loggedInMember = memberRepository.GetMemberById(memberId);
            }
            frmMembers_Load(sender, e);

        }

        private void gvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            if (gvMember.SelectedCells.Count > 0)
            {
                int selectedRowIndex = gvMember.SelectedRows[0].Index;
                DataGridViewRow selectedRow = gvMember.Rows[selectedRowIndex];

                txtMemberId.Text = Convert.ToString(selectedRow.Cells["MemberId"].Value);
                txtEmail.Text = Convert.ToString(selectedRow.Cells["Email"].Value);
                txtCompany.Text = Convert.ToString(selectedRow.Cells["CompanyName"].Value);
                txtCity.Text = Convert.ToString(selectedRow.Cells["City"].Value);
                txtCountry.Text = Convert.ToString(selectedRow.Cells["Country"].Value);

            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreateMember frmCreateMember = new frmCreateMember();
            frmCreateMember.ShowDialog();
            frmMembers_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gvMember.SelectedCells.Count > 0)
            {
                int selectedRowIndex = gvMember.SelectedRows[0].Index;
                DataGridViewRow selectedRow = gvMember.Rows[selectedRowIndex];

                DialogResult result = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int memberId = Convert.ToInt32(selectedRow.Cells["MemberId"].Value);
                    IMemberRepository memberRepository = new MemberRepository();
                    memberRepository.DeleteMember(memberId);
                    frmMembers_Load(sender, e);

                }




            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders = new frmOrders(loggedInMember);
            frmOrders.ShowDialog();

        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            frmOrders frmOrders = new frmOrders(loggedInMember);
            frmOrders.ShowDialog();
        }
    }
}
