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
            dtgvProduct.DataSource = ProductsDAO.Instance.ListProduct();
            dtgvProduct.AutoResizeColumns();
        }

        private void dtgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0) return;
            dtgvProduct.Rows[row].Selected = true;
            txtProductId.Enabled = false;
            txtProductId.Text = dtgvProduct.Rows[row].Cells["Mã Sản Phẩm"].Value.ToString();
            txtProductNameType.Text = dtgvProduct.Rows[row].Cells["Loại Sản Phẩm"].Value.ToString();
            txtProductName.Text = dtgvProduct.Rows[row].Cells["Tên Sản Phẩm"].Value.ToString();
            txtPrice.Text = dtgvProduct.Rows[row].Cells["Giá"].Value.ToString();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtProductId.Enabled = true;
            txtProductId.Text = "";
            txtProductNameType.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";

           
        }

     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int productId = (int)Convert.ToInt32(txtProductId.Text);
            string productName = txtProductName.Text;
            string productType = txtProductNameType.Text;
            float productPrice = (float)Convert.ToDouble(txtPrice.Text);
            InsertProduct(productId, productName, productType, productPrice);
        }

        void InsertProduct(int productId, string productName, string productType, float productPrice)
        {
            if (ProductsDAO.Instance.InsertProduct(productId, productName, productType, productPrice))
            {
                MessageBox.Show("Thêm sản phẩm thành công !");
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại !");
            }
            LoadProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
