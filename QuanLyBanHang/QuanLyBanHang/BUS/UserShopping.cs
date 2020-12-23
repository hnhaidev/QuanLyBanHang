using QuanLyBanHang.BUS;
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
    public partial class UserShopping : UserControl
    {
        public static double payment;
        public UserShopping()
        {
            InitializeComponent();
            LoadCbbProductType();
        }
        void LoadCbbProductType()
        {
            List<ProductType> listProductType = ProductTypeDAO.Instance.GetListProductType();
            cbbProductType.DataSource = listProductType;
            cbbProductType.DisplayMember = "productTypeName";          
        }
        void LoadCbbProduct(int id)
        {
            List<Products> listProduct = ProductsDAO.Instance.GetListProduct(id);
            cbbProduct.DataSource = listProduct;
            cbbProduct.DisplayMember = "ProductName";
        }

        private void cbbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            ProductType selected = cb.SelectedItem as ProductType;
            id = selected.ProductTypeId;
            LoadCbbProduct(id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool product = false;

            int productId = (cbbProduct.SelectedItem as Products).ProductId;
            string productName = (cbbProduct.SelectedItem as Products).ProductName;
            int productAmount = (int)nmudAmout.Value;
            string productPrice = (cbbProduct.SelectedItem as Products).ProductPrice.ToString("###,###");
            string salePrice = (productAmount * double.Parse(productPrice)).ToString("###,###");

            if (dtgvProductInfo.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtgvProductInfo.Rows)
                {
                    //neu them san pham giong nhau se cộng dồn số lượng và tiền vào ô
                    if ((int)row.Cells[0].Value == productId)
                    {
                        row.Cells[2].Value = productAmount + (int)row.Cells[2].Value;
                        row.Cells[4].Value = ((double.Parse(salePrice) + Convert.ToDouble(row.Cells[4].Value.ToString()))).ToString("###,###");
                        product = true;
                    }
                }
                if(!product)
                {
                    dtgvProductInfo.Rows.Add(productId, productName, productAmount, productPrice, salePrice);
                }
            }
            else
            {
                dtgvProductInfo.Rows.Add(productId, productName, productAmount, productPrice, salePrice);
            }

            //------------ tinh tong tien sp trong datagridview-------------///
            double sum = 0;
            for (int i = 0; i < dtgvProductInfo.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dtgvProductInfo.Rows[i].Cells[4].Value);
            }
            txtSumPrice.Text = sum.ToString("###,###");



            //---------------Refesh lại amount -----------------------//
            nmudAmout.Value = 1;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtClinetPhone.Text;
            Client client = SearchClientByPhone(phoneNumber);
            if (client != null)
            {
                txtClinetName.Text = client.ClientName;
                txtAddress.Text = client.Address;

                txtAddress.Enabled = false;
                txtClinetName.Enabled = false;
                txtClinetPhone.Enabled = false;
                btnSaveClient.Enabled = false;
              //  nmudPayAmount.Value = BillDAO.Instance.CountClientPay(phoneNumber);
            }
            else
            {
                MessageBox.Show("Không tìm thấy SĐT cần tìm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtClinetPhone.Text;
            string clientName = txtClinetName.Text;
            string address = txtAddress.Text;

            txtClinetPhone.Enabled = false;
            txtAddress.Enabled = false;
            txtClinetName.Enabled = false;
           // nmudPayAmount.Value = BillDAO.Instance.CountClientPay(phoneNumber);

            InsertClient(phoneNumber, clientName, address);
        }
        void InsertClient(string phoneNumber, string clientName, string address)
        {
            if (ClientDAO.Instance.InsertClient(phoneNumber, clientName, address)) 
            {
                MessageBox.Show("Lưu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtClinetPhone_KeyDown(object sender, KeyEventArgs e)
        {
        }
        Client SearchClientByPhone(string phoneNumber)
        {
            Client listClient = ClientDAO.Instance.SearchClientByPhone(phoneNumber);
            return listClient;
        }
        private void txtSumPrice_TextChanged(object sender, EventArgs e)
        {
            txtPay.Text = txtSumPrice.Text;
        }
        private void txtDisCount_TextChanged(object sender, EventArgs e)
        {
            txtPercent.Enabled = false;
            if(string.IsNullOrWhiteSpace(txtDisCount.Text))
            {
                txtPay.Text = txtSumPrice.Text;
                txtPercent.Enabled = true;
                txtDisCount.Enabled = true;
            }
            else if (txtDisCount.Text.StartsWith(","))
            {
                MessageBox.Show("lỗi dấu ,");
            }
            else
            {
                double sumPrice = double.Parse(txtSumPrice.Text);
                double disCount = double.Parse(txtDisCount.Text);
                if(disCount > sumPrice)
                {
                    MessageBox.Show("Số tiền giảm lớn hơn tổng tiền", "Lỗi");
                    txtPay.Text = txtSumPrice.Text;
                }
                else
                {
                    txtPay.Text = (sumPrice - disCount).ToString("###,###");
                }

            }
        }

        private void txtPercent_TextChanged(object sender, EventArgs e)
        {
            txtDisCount.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtPercent.Text))
            {
                txtPay.Text = txtSumPrice.Text;
                txtDisCount.Enabled = true;
                txtPercent.Enabled = true;
            }
            else if (txtPercent.Text.StartsWith("."))
            {
                MessageBox.Show("Lỗi dấu .");
            }
            else
            {
                double sumPrice = double.Parse(txtSumPrice.Text);
                double percent = double.Parse(txtPercent.Text);
                if (percent < 0)
                {
                    MessageBox.Show("Sai tham số < 0", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPay.Text = txtSumPrice.Text;
                }

                else if (percent > 100)
                {
                    MessageBox.Show("Sai tham số > 100", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPay.Text = txtSumPrice.Text;
                }
                else if (percent > 0 && percent < 100)
                {
                    txtPay.Text = (sumPrice - (sumPrice * percent) / 100).ToString("###,###");
                }
            }
        }

        //---------------Không cho người dùng nhập chữ ----------------//
        private void txtDisCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(txtClinetPhone.Enabled == false)
            {
                int productID;
                int amount;
                int staffId = fLogin.staffID;
                string phoneClient = txtClinetPhone.Text;

                BillDAO.Instance.InsertBill(phoneClient, staffId);

                foreach (DataGridViewRow row in dtgvProductInfo.Rows)
                {
                    productID = int.Parse(row.Cells[0].Value.ToString());
                    amount = int.Parse(row.Cells[2].Value.ToString());
                    //------------- InsertBill ----------------//
                    BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), productID, amount);
                    //------------- UpdateProductAmount ----------------//
                    ProductsDAO.Instance.UpdateProductAmount(productID, amount);
                }
                payment = double.Parse(txtPay.Text);

                //----------- Chuyển trang -----------//
                fPayment fPayment = new fPayment();
                fPayment.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập và lưu thông tin khách hàng để thực hiện tiếp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void nmudAmout_ValueChanged(object sender, EventArgs e)
        {
            int currentQuantity = (cbbProduct.SelectedItem as Products).ProductAmount;
            int purchasedQuantity = int.Parse(nmudAmout.Value.ToString());
            if (currentQuantity < purchasedQuantity)
            {
                MessageBox.Show("Số lượng trong kho còn lại không đủ.\nSố lượng còn lại: " + currentQuantity);
            }
            nmudAmout.Maximum = currentQuantity;
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            txtAddress.Enabled = true;
            txtClinetName.Enabled = true;
            txtClinetPhone.Enabled = true;
            btnSaveClient.Enabled = true;

            txtAddress.Text = "";
            txtClinetName.Text = "";
            txtClinetPhone.Text = "";

            dtgvProductInfo.Rows.Clear();
            dtgvProductInfo.Refresh();
        }
    }
}
