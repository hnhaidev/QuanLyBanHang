using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class UserAccount : UserControl
    {
        public UserAccount()
        {
            InitializeComponent();
            LoadAccount();
        }
        void LoadAccount()
        {
            dtgvAccount.DataSource = AccountDAO.Instance.GetListAccount();
            dtgvAccount.EndEdit();
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            int row = e.RowIndex;
            if (row < 0) return;
            dtgvAccount.Rows[row].Selected = true;
            txtUserName.Enabled = false;

            txtUserName.Text = dtgvAccount.Rows[row].Cells["Tên Tài Khoản"].Value.ToString();
            txtPassWord.Text = dtgvAccount.Rows[row].Cells["Mật Khẩu"].Value.ToString();
            txtStaffId.Text = dtgvAccount.Rows[row].Cells["Mã Nhân Viên"].Value.ToString();
            if (Convert.ToInt32(dtgvAccount.Rows[row].Cells["Chức Vụ"].Value) == 1)
            {
                rdoManage.Checked = true;
            }
            else
            {
                rdStaff.Checked = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int staffId = (int)Convert.ToInt32(txtStaffId.Text);
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            int accountType = 0;
            if (rdoManage.Checked == true)
            {
                accountType = 1; 
            }
            else
            {
                accountType = 0;
            }
            if (txtPassWord.Text == txtReconfirmPW.Text)
            {
                InsertAccount(staffId, userName, passWord, accountType);
            }
            else
            {
                MessageBox.Show("Mật khẩu không trùng khớp!","Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void InsertAccount(int staffId, string userName, string passWord, int accountType)
        {
            if (AccountDAO.Instance.InserAccount(staffId, userName, passWord, accountType))
            {
                MessageBox.Show("Thêm tài khoản thành công !");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại !");
            }
            LoadAccount();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int staffId = (int)Convert.ToInt32(txtStaffId.Text);
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            int accountType = 0;
            if (rdoManage.Checked == true)
            {
                accountType = 1;
            }
            else
            {
                accountType = 0;
            }
            if (txtPassWord.Text == txtReconfirmPW.Text)
            {
                UpdateAccount(staffId, userName, passWord, accountType);
            }
            else
            {
                MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void UpdateAccount(int staffId, string userName, string passWord, int accountType)
        {
            if (AccountDAO.Instance.UpdateAccount(staffId, userName, passWord, accountType))
            {
                MessageBox.Show("Sửa tài khoản thành công !");
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại !");
            }
            LoadAccount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            DeleteAccount(userName);
        }
        void DeleteAccount(string userName)
        {
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công !");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại !");
            }
            LoadAccount();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtUserName.Enabled = true;
            txtUserName.Text = "";
            txtPassWord.Text = "";
            txtReconfirmPW.Text = "";
            txtStaffId.Text = "";
            LoadAccount();
        }
    }
}
