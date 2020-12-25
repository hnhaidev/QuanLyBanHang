using QuanLyBanHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI
{
    public partial class fBillInfo : Form
    {
        Label lbLoichao = new Label();
        public fBillInfo()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            int id = UserBill.idBill;
            lbClientName.Text = UserBill.ClientName;
            lbStaffName.Text = UserBill.StaffName;
            lbSumMoney.Text = UserBill.SumMoney.ToString("###,###") + " VNĐ";
            dtgrvListBillInfo.DataSource = BillInfoDAO.Instance.ListBillById(id);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            }

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //--------------------------------------------//
            string lbtenshop = "Cửa Hàng Điện Máy NGUYỄN KIM";
            string lbdiachi = "99 Lê Văn Việt, P.Tăng Nhơn Phú A, Quận 9, Hồ Chí Minh, Thành phố Hồ Chí Minh";
            string lbSDT = "01010101";

            //double cash = double.Parse(lbSumMoney.Text);
            //double change = 0;

            //this prints the reciept
            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 12); //must use a mono spaced font as the spaces need to line up

            double fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString(lbtenshop, new Font("Courier New", 18), new SolidBrush(Color.Black), startX, startY);

            graphic.DrawString(lbdiachi, font, new SolidBrush(Color.Black), startX, 40);

            graphic.DrawString(lbSDT, font, new SolidBrush(Color.Black), startX, 60);

            offset = offset + 50;
            string top = "Sản phẩm".PadRight(21) + "SL".PadRight(10) + "Giá".PadRight(10);
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent


            double totalprice = 0;
            DataTable data = BillInfoDAO.Instance.ListBillById(UserBill.idBill);
            foreach (DataRow row in data.Rows)
            {
                string productName = row["Product Name"].ToString();
                int amount = (int)row["Amount"];
                double payMoney = (double)row["Price"];
                //    MessageBox.Show(productPrice.ToString());
                //create the string to print on the reciept
                //  string productDescription = item;
                //string productTotal = item.Substring(item.Length - 6, 6);
                double productTotal = UserBill.SumMoney;
                //   float productPrice = float.Parse(item.Substring(item.Length - 5, 5));

                //totalprice += productPrice;
                totalprice = productTotal;

                string ten = productName;
                string dongia = payMoney.ToString();
                string slsp = amount.ToString();
                graphic.DrawString(ten, font, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString(slsp, font, new SolidBrush(Color.Black), 230, startY + offset);
                graphic.DrawString(dongia, font, new SolidBrush(Color.Black), 320, startY + offset);
                offset = offset + (int)fontHeight + 5; //make the spacing consistent


            }

            //change = float.Parse(txtExtraMoney.Text);

            //when we have drawn all of the items add the total

            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("Tổng cộng ".PadRight(30) + totalprice.ToString("###,###"), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 30; //make some room so that the total stands out.
            //graphic.DrawString("Tiền khách đưa ".PadRight(30) + cash.ToString("###,###"), font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 15;
            //graphic.DrawString("Tiền thối lại ".PadRight(30) + change.ToString("###,###"), font, new SolidBrush(Color.Black), startX, startY + offset);
           // offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString(lbLoichao.Text, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
        }
    }
}
