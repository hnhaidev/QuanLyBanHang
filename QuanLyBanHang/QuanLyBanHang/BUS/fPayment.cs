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
    public partial class fPayment : Form
    {
        public fPayment()
        {
            InitializeComponent();
            txtPayment.Text = UserShopping.payment.ToString("###,###");
        }

        private void btn50k_Click(object sender, EventArgs e)
        {
            double money = 50000;
            txtClientMoney.Text = money.ToString("###,###");
        }

        private void btn100k_Click(object sender, EventArgs e)
        {
            double money = 100000;
            txtClientMoney.Text = money.ToString("###,###");
        }

        private void btn200k_Click(object sender, EventArgs e)
        {
            double money = 200000;
            txtClientMoney.Text = money.ToString("###,###");
        }

        private void btn500k_Click(object sender, EventArgs e)
        {
            double money = 500000;
            txtClientMoney.Text = money.ToString("###,###");
        }

        private void btnPayEnough_Click(object sender, EventArgs e)
        {
            txtClientMoney.Text = txtPayment.Text;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClientMoney_TextChanged(object sender, EventArgs e)
        {
            double payment = double.Parse(txtPayment.Text);
            double clientMoney = double.Parse(txtClientMoney.Text);

            double extraMoney = clientMoney - payment;
            if (extraMoney == 0)
            {
                txtExtraMoney.Text = "0";
            }
            else
            {
                txtExtraMoney.Text = extraMoney.ToString("###,###");
            }
        }

        private void txtClientMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }
    }
}
