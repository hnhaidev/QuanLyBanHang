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
    public partial class fMain : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value;}
        }

        public fMain(Account account)
        {
            this.LoginAccount = account;
            InitializeComponent();
            txtUserName.Text = LoginAccount.UserName;
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            LoadSidePanel(btnHome);
            userHome1.BringToFront();
            timer1.Enabled = true;
            timer1.Start();
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }
        public void LoadSidePanel(Button bt)
        {
            SidePanel.Height = bt.Height;
            SidePanel.Top = bt.Top;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadSidePanel(btnHome);
            userHome1.BringToFront();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            if(loginAccount.AccountType == 0)
            {
                LoadSidePanel(btnAccount);
                userAccount1.BringToFront();
            }
            else
            {
                MessageBox.Show("Quản lý mới vào được mục này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShopping_Click(object sender, EventArgs e)
        {
            LoadSidePanel(btnShopping);
            userShopping1.BringToFront();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            LoadSidePanel(btnBill);
            userBill1.BringToFront();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (loginAccount.AccountType == 0)
            {
                LoadSidePanel(btnProducts);
                userProducts1.BringToFront();
            }
            else
            {
                MessageBox.Show("Quản lý mới vào được mục này!", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStatistical_Click(object sender, EventArgs e)
        {
            LoadSidePanel(btnStatistical);
            userStatistical1.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn đăng xuất ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.OK:
                    fLogin f = new fLogin();
                    this.Close();
                    f.Show();
                    break;
                default:
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn thoát chương trình không ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.OK:
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn muốn hỏi gì nào ?", "Question ?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
