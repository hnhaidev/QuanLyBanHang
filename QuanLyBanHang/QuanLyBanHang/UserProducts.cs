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
    public partial class UserProducts : UserControl
    {
        public UserProducts()
        {
            InitializeComponent();
            LoadProduct();
        }

        void LoadProduct()
        {
            dgvProduct.DataSource = ProductsDAO.Instance.ListProduct();
            dgvProduct.AutoResizeColumns();
        }
    }
}
