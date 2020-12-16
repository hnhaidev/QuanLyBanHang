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
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
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
        void LoadDtgv()
        {
            DataTable data = new DataTable();
            data.Columns.Add("Tên Sản Phẩm", System.Type.GetType("System.String"));
            data.Columns.Add("Số Lượng", System.Type.GetType("System.Int32"));
            data.Columns.Add("Giá", System.Type.GetType("System.String"));
            dtgvProductInfo.DataSource = data;
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
            int productId = (cbbProduct.SelectedItem as Products).ProductId;
            int amount = (int)nmudAmout.Value;
            BillDAO.Instance.InsertBill(LoginAccount.StaffId, txtClinetPhone.Text);
            BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), productId, amount);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtClinetPhone.Text;
            if (SearchClientByPhone(phoneNumber).Count > 0)
            {
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

            InsertClient(phoneNumber, clientName, address);
            labelClientName.Text = clientName;
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
        List<Client> SearchClientByPhone(string phoneNumber)
        {
            List<Client> listClient = ClientDAO.Instance.SearchClientByPhone(phoneNumber);
            return listClient;
        }
    }
}
