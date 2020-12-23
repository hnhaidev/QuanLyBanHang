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
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyBanHang
{
    public partial class UserStatistical : UserControl
    {
        public UserStatistical()
        {
            InitializeComponent();
            LoadStatisticals();
            chartAlmostProduct.Hide();
            chartProduct.Hide();
            chartMoney.Show();
            LoadChartMoney();
        }
        void LoadStatisticals()
        {
            //-----------------------------------Bill-----------------------------------//
            lbSumBill.Text = BillDAO.Instance.SumBillMonth().ToString();
            if (BillDAO.Instance.SumBillDay()  > 0)
            {
                lbBilltoday.Text = "Today: " + BillDAO.Instance.SumBillDay().ToString();
            }
            else
            {
                lbBilltoday.Text = "Today: " + 0;
            }

            //-----------------------------------Product-----------------------------------//
            lbSumProductMonth.Text = BillDAO.Instance.SumPayProductMonth().ToString();
            if (BillDAO.Instance.SumPayProductDay() > 0)
            {
                lbSumProductToday.Text = "Today: " + BillDAO.Instance.SumPayProductDay().ToString();
            }
            else
            {
                lbSumProductToday.Text = "Today: " + 0;
            }

            //-----------------------------------Money-----------------------------------//
            lbMoneyMonth.Text = BillDAO.Instance.SumMoneyMonth().ToString("###,###");
            if (BillDAO.Instance.SumMoneyDay() > 0)
            {
                lbMoneyDay.Text = "Today: " + BillDAO.Instance.SumMoneyDay().ToString("###,###");
            }
            else
            {
                lbMoneyDay.Text = "Today: " + 0;
            }

            //-----------------------------------Product and ProductType Trong Kho, Nhân viên-----------------------------------//
            lbTotalProduct.Text = ProductsDAO.Instance.SumProduct().ToString();
            lbProductType.Text = ProductTypeDAO.Instance.SumProductType().ToString();
            lbStaff.Text = StaffDAO.Instance.SumStaff().ToString();
        }

        void LoadChartMoney()
        {
            chartMoney.Series["Series1"].XValueType = ChartValueType.DateTime;

            chartMoney.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";

            chartMoney.DataSource = BillDAO.Instance.SumPayMoneyByDay();

            //set the member of the chart data source used to data bind to the X-values of the series  
            chartMoney.Series["Series1"].XValueMember = "Ngay";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chartMoney.Series["Series1"].YValueMembers = "tien";
            chartMoney.Series["Series1"].IsValueShownAsLabel = true;
        }
        void LoadChartProduct()
        {
            chartProduct.Series["Series1"].XValueType = ChartValueType.DateTime;
            chartProduct.Series["Series1"].YValueType = ChartValueType.Int32;
            chartProduct.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";

            chartProduct.DataSource = BillDAO.Instance.TotalPayProductByDay();

            //set the member of the chart data source used to data bind to the X-values of the series  
            chartProduct.Series["Series1"].XValueMember = "Ngay";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chartProduct.Series["Series1"].YValueMembers = "slsp";
            chartProduct.Series["Series1"].IsValueShownAsLabel = true;
        }
        void LoadchartAlmostProduct()
        {
            chartAlmostProduct.DataSource = ProductsDAO.Instance.ProductAlmostOfStock();

            //set the member of the chart data source used to data bind to the X-values of the series  
            chartAlmostProduct.Series["Series1"].XValueMember = "Ten";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            chartAlmostProduct.Series["Series1"].YValueMembers = "SL";
            chartAlmostProduct.Series["Series1"].IsValueShownAsLabel = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            chartMoney.Show();
            chartProduct.Hide();
            chartAlmostProduct.Hide();

            LoadChartMoney();
        }
        private void btnChartProduct_Click(object sender, EventArgs e)
        {
            chartMoney.Hide();
            chartProduct.Show();
            chartAlmostProduct.Hide();

            LoadChartProduct();
        }
        private void btnProductAlmostOfStock_Click(object sender, EventArgs e)
        {
            chartMoney.Hide();
            chartProduct.Hide();
            chartAlmostProduct.Show();

            LoadchartAlmostProduct();
        }

    }
}
