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
    public partial class UserProducts : UserControl
    {
        BindingSource productList = new BindingSource();
        public UserProducts()
        {
            InitializeComponent();
            dtgvProduct.DataSource = productList;

            LoadProduct();
            LoadCbbProductType();
            AddFoodBinding();
        }

        void LoadProduct()
        {
            productList.DataSource = ProductsDAO.Instance.ListProduct();
        }
        void LoadCbbProductType()
        {
            cbbProductType.DataSource = ProductTypeDAO.Instance.GetListProductType();
            cbbProductType.DisplayMember = "productTypeName";
        }
        void AddFoodBinding()
        {
            txtProductName.DataBindings.Add(new Binding("Text", dtgvProduct.DataSource, "Tên Sản Phẩm", true, DataSourceUpdateMode.Never));
            txtProductId.DataBindings.Add(new Binding("Text", dtgvProduct.DataSource, "Mã Sản Phẩm", true, DataSourceUpdateMode.Never));
            txtPrice.DataBindings.Add(new Binding("Text", dtgvProduct.DataSource, "Giá", true, DataSourceUpdateMode.Never));
            nmudProductAmount.DataBindings.Add(new Binding("Value", dtgvProduct.DataSource, "Số lượng", true, DataSourceUpdateMode.Never));
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            nmudProductAmount.Value = 0;

            LoadCbbProductType();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string productName = txtProductName.Text;
            int productTypeId = (cbbProductType.SelectedItem as ProductType).ProductTypeId;
            float productPrice = (float)Convert.ToDouble(txtPrice.Text);
            int productAmount = (int)nmudProductAmount.Value;

            InsertProduct(productName, productTypeId, productPrice, productAmount);
        }

        void InsertProduct(string productName, int productTypeId, float productPrice, int productAmount)
        {
            if (ProductsDAO.Instance.InsertProduct(productName, productTypeId, productPrice, productAmount))
            {
                MessageBox.Show("Thêm sản phẩm thành công !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(txtProductId.Text);
            string productName = txtProductName.Text;
            int productTypeId = (cbbProductType.SelectedItem as ProductType).ProductTypeId;
            float productPrice = (float)Convert.ToDouble(txtPrice.Text);
            int productAmount = (int)nmudProductAmount.Value;

            UpdateProduct(productId, productName, productTypeId, productPrice, productAmount);
        }
        void UpdateProduct(int productId, string productName, int productTypeId, float productPrice, int productAmount)
        {
            if (ProductsDAO.Instance.UpdateProduct(productId, productName, productTypeId, productPrice, productAmount))
            {
                MessageBox.Show("Sửa sản phẩm thành công !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa sản phẩm thất bại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(txtProductId.Text);
            DeleteProduct(productId);
        }
        public void DeleteProduct(int productID)
        {
            if (ProductsDAO.Instance.DeleteProduct(productID))
            {
                MessageBox.Show("Xóa sản phẩm thành công !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadProduct();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtgvProduct.DataSource = SearchProductByName(txtSearch.Text);
        }
        List<Products> SearchProductByName(string productName)
        {
            List<Products> listProduct = ProductsDAO.Instance.SearchProductByName(productName);
            return listProduct;
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvProduct.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvProduct.SelectedCells[0].OwningRow.Cells["Mã Loại Sản Phẩm"].Value;

                    ProductType productType = ProductTypeDAO.Instance.GetProductTypeById(id);

                    //cbbProductType.SelectedItem = productType;

                    int index = -1;
                    int i = 0;
                    foreach (ProductType item in cbbProductType.Items)
                    {
                        if (item.ProductTypeId == productType.ProductTypeId)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbbProductType.SelectedIndex = index;
                }
            }
            catch { }
        }
    }
}
