﻿using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.BUS
{
    public partial class UserStaff : UserControl
    {
        public UserStaff()
        {
            InitializeComponent();
            LoadStaff();
        }
        void LoadStaff()
        {
            dtgrListStaff.DataSource = StaffDAO.Instance.GetListStaff();
        }

        private void dtgrListStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) return;
            dtgrListStaff.Rows[row].Selected = true;

            txtStaffName.Text = dtgrListStaff.Rows[row].Cells["Tên Nhân Viên"].Value.ToString();
            txtStaffId.Text = dtgrListStaff.Rows[row].Cells["Mã Nhân Viên"].Value.ToString();
            txtAddress.Text = dtgrListStaff.Rows[row].Cells["Quê Quán"].Value.ToString();
            txtPhoneNumber.Text = dtgrListStaff.Rows[row].Cells["Số ĐT"].Value.ToString();
            dtpDateOfBirth.Value = (DateTime)(dtgrListStaff.Rows[row].Cells["Ngày Sinh"].Value);
            if (Convert.ToBoolean(dtgrListStaff.Rows[row].Cells["Giới Tính"].Value) == true)
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtStaffId.Text = "";
            txtStaffName.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            txtAddress.Text = "";

            LoadStaff();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string staffName = txtStaffName.Text;
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            bool gender;
            if (rdMale.Checked == true)
            {
                gender = true;
            }
            else
            {
                gender = false;
            }

            InsertStaff(staffName, dateOfBirth, address, phoneNumber, gender);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtStaffId.Text);
            string staffName = txtStaffName.Text;
            DateTime dateOfBirth = dtpDateOfBirth.Value;
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            bool gender;
            if (rdMale.Checked == true)
            {
                gender = true;
            }
            else
            {
                gender = false;
            }

            UpdateStaff(id, staffName, dateOfBirth, address, phoneNumber, gender);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtStaffId.Text);

            DeleteStaff(id);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (StaffDAO.Instance.SearchStaffByName(txtSearch.Text).Rows.Count > 0)
            {
                dtgrListStaff.DataSource = StaffDAO.Instance.SearchStaffByName(txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tên nhân viên cần tìm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void InsertStaff(string staffName, DateTime dateOfBirth, string address, string phoneNumber, bool gender)
        {
            if(StaffDAO.Instance.InsertStaff(staffName, dateOfBirth, address, phoneNumber,  gender))
            {
                MessageBox.Show("Thêm nhân viên thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm nhân viên lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void UpdateStaff(int id, string staffName, DateTime dateOfBirth, string address, string phoneNumber, bool gender)
        {
            if (StaffDAO.Instance.UpdateStaff(id, staffName, dateOfBirth, address, phoneNumber, gender))
            {
                MessageBox.Show("Sửa nhân viên thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa nhân viên lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void DeleteStaff(int id)
        {
            if (StaffDAO.Instance.DeleteStaff(id))
            {
                MessageBox.Show("Xóa nhân viên thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa nhân viên lỗi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
