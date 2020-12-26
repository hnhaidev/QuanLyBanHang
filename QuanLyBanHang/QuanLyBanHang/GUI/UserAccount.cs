using QuanLyBanHang.DAO;
using QuanLyBanHang.DTO;
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
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            int row = e.RowIndex;
            if (row < 0) return;
            dtgvAccount.Rows[row].Selected = true;
            txtUserName.Enabled = false;

            txtUserName.Text = dtgvAccount.Rows[row].Cells["User Name"].Value.ToString();
            txtStaffId.Text = dtgvAccount.Rows[row].Cells["Staff ID"].Value.ToString();
            int accountType = Convert.ToInt32(dtgvAccount.Rows[row].Cells["Account Type"].Value.ToString());
            if (accountType == 0)
            {
                rdoManage.Checked = true;
            }
            else if (accountType == 1)
            {
                rdoSalesman.Checked = true;
            }
            else if (accountType == 2)
            {
                rdoAccountant.Checked = true;
            }
            else if (accountType == 3)
            {
                radoStocker.Checked = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetListAccountByName(txtSearch.Text);
        }
        public void GetListAccountByName(string name)
        {
            if (AccountDAO.Instance.GetListAccountByName(name).Rows.Count > 0)
            {
                dtgvAccount.DataSource = AccountDAO.Instance.GetListAccountByName(name);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản cần tìm !");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtUserName.Enabled == false)
            {
                MessageBox.Show("Vui lòng Refesh để nhập tên tài khoản khác !");
            }
            else
            {
                int staffId = (int)Convert.ToInt32(txtStaffId.Text);
                string userName = txtUserName.Text;
                string passWord = txtPassWord.Text;
                int accountType = 0;
                if (rdoManage.Checked == true)
                {
                    accountType = 0;
                }
                else if(rdoSalesman.Checked ==  true)
                {
                    accountType = 1;
                }
                else if (rdoAccountant.Checked == true)
                {
                    accountType = 2;
                }
                else if (radoStocker.Checked == true)
                {
                    accountType = 3;
                }

                // Kiểm tra nhập
                if (txtStaffId.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Vui lòng nhập Mã nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (AccountDAO.Instance.CheckByStaffId(Convert.ToInt32(txtStaffId.Text)))
                {
                    MessageBox.Show("Nhân viên này đã có tài khoản!", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUserName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (AccountDAO.Instance.GetListAccountByName(txtUserName.Text).Rows.Count > 0)
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPassWord.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPassWord.Text != txtReconfirmPW.Text)
                {
                    MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    InsertAccount(staffId, userName, passWord, accountType);
                }
            }
        }
        void InsertAccount(int staffId, string userName, string passWord, int accountType)
        {
            if (AccountDAO.Instance.InserAccount(staffId, userName, passWord, accountType))
            {
                MessageBox.Show("Thêm tài khoản thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại !","Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadAccount();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtUserName.Enabled == false)
            {
                if (txtUserName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Vui lòng nhập tên tài khoản !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int staffId = (int)Convert.ToInt32(txtStaffId.Text);
                    string userName = txtUserName.Text;
                    string passWord = txtPassWord.Text;
                    int accountType = 0;
                    if (rdoManage.Checked == true)
                    {
                        accountType = 0;
                    }
                    else if (rdoSalesman.Checked == true)
                    {
                        accountType = 1;
                    }
                    else if (rdoAccountant.Checked == true)
                    {
                        accountType = 2;
                    }
                    else if (radoStocker.Checked == true)
                    {
                        accountType = 3;
                    }

                    // Kiểm tra nhập
                    if (txtStaffId.Text.Trim().Length < 1)
                    {
                        MessageBox.Show("Vui lòng nhập Mã nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtPassWord.Text.Trim().Length < 1)
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtPassWord.Text != txtReconfirmPW.Text)
                    {
                        MessageBox.Show("Mật khẩu không trùng khớp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtPassWord.Text = "";
                        txtReconfirmPW.Text = "";
                        UpdateAccount(staffId, userName, passWord, accountType);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa !");
            }
        }
        void UpdateAccount(int staffId, string userName, string passWord, int accountType)
        {
            if (AccountDAO.Instance.UpdateAccount(staffId, userName, passWord, accountType))
            {
                MessageBox.Show("Sửa tài khoản thành công !","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại !","Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadAccount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtUserName.Enabled == true)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtUserName.Text == fLogin.userNames)
            {
                MessageBox.Show("Không được xóa tài khoản đang đăng nhập !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtPassWord.Text = "";
                txtReconfirmPW.Text = "";

                string userName = txtUserName.Text;
                DeleteAccount(userName);
            }
        }
        void DeleteAccount(string userName)
        {
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
