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
            txtProductName.DataBindings.Add(new Binding("Text", dtgvProduct.DataSource, "Product Name", true, DataSourceUpdateMode.Never));
            txtProductId.DataBindings.Add(new Binding("Text", dtgvProduct.DataSource, "Product ID", true, DataSourceUpdateMode.Never));
            txtPrice.DataBindings.Add(new Binding("Text", dtgvProduct.DataSource, "Price", true, DataSourceUpdateMode.Never));
            nmudProductAmount.DataBindings.Add(new Binding("Value", dtgvProduct.DataSource, "Amount", true, DataSourceUpdateMode.Never));
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
            if(txtProductId.Text.Trim().Length > 0)
            {
                MessageBox.Show("Vui lòng refesh để thực hiện chức năng này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtProductName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPrice.Text.Trim().Length < 1)
            {
                MessageBox.Show("Vui lòng nhập giá sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (nmudProductAmount.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                InsertProduct(productName, productTypeId, productPrice, productAmount);
            }
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
            if(txtProductId.Text.Trim().Length > 0)
            {
                int productId = Convert.ToInt32(txtProductId.Text);
                string productName = txtProductName.Text;
                int productTypeId = (cbbProductType.SelectedItem as ProductType).ProductTypeId;
                float productPrice = (float)Convert.ToDouble(txtPrice.Text);
                int productAmount = (int)nmudProductAmount.Value;
                if (txtProductName.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtPrice.Text.Trim().Length < 1)
                {
                    MessageBox.Show("Vui lòng nhập giá sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (nmudProductAmount.Value == 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    UpdateProduct(productId, productName, productTypeId, productPrice, productAmount);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Sản phẩm cần sửa !");
            }

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
            if (txtProductId.Text.Trim().Length > 0)
            {
                int productId = Convert.ToInt32(txtProductId.Text);
                DeleteProduct(productId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Sản phẩm cần xóa !");
            }
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
            if(ProductsDAO.Instance.SearchProductByName(txtSearch.Text).Rows.Count > 0)
            {
                dtgvProduct.DataSource = ProductsDAO.Instance.SearchProductByName(txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Không tìm thấy !");
            }
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvProduct.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvProduct.SelectedCells[0].OwningRow.Cells["Product Type ID"].Value;

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
