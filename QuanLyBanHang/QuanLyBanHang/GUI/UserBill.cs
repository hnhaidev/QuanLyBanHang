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
    public partial class UserBill : UserControl
    {
        public UserBill()
        {
            InitializeComponent();
            LoadBIll();
        }
        void LoadBIll()
        {
            dtgrBill.DataSource = BillDAO.Instance.GetListBill();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(BillDAO.Instance.SearchBill(txtSearch.Text).Rows.Count > 0)
            {
                dtgrBill.DataSource = BillDAO.Instance.SearchBill(txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Không tìm thấy !");
            }
        }

        private void dtpSearch_ValueChanged(object sender, EventArgs e)
        {
            if (BillDAO.Instance.SearchBillByDay(dtpSearch.Value).Rows.Count > 0)
            {
                dtgrBill.DataSource = BillDAO.Instance.SearchBillByDay(dtpSearch.Value);
            }
            else
            {
                MessageBox.Show("Không có hóa đơn ngày này!");
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadBIll();
        }
    }
}
