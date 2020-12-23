using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return instance;
            }
            private set => instance = value; 
        }
        public int GetMaxIdBill()
        {
            try 
            {
                return (int)DataProvider.Instance.ExecuteScalar("select MAX(billId) from Bill");
            }
            catch 
            {
                return 1;
            }
        }
        public void InsertBill(string clientPhone, int staffId)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBill @clientPhone , @staffId ", new object[] { clientPhone, staffId });
        }
        public int CountClientPay(string phoneNumber)
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select count(*) from Bill where phoneNumber =" + phoneNumber);
            }
            catch
            {
                return 0;
            }
        }
        public DataTable GetListBill()
        {
            return DataProvider.Instance.ExecuteQuery("USP_GetListBill");
        }
        public DataTable PrintBill()
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_ExportBillInfo"); 
        }
        public int SumBillMonth()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT count( MONTH(billDate)) as HDtimene from Bill where MONTH(billDate) = '" + DateTime.Now.ToString("MM") + "'  ");
            }
            catch
            {
                return 0;
            }
        }
        public int SumBillDay()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select count(billId) from Bill where cast (billDate as date) = cast(getdate() as date)");
            }
            catch
            {
                return 0;
            }
        }
        public int SumPayProductMonth()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select sum(BillInfo.amount) from Bill, BillInfo Where Bill.billId = BillInfo.billId and MONTH(billDate) = '" + DateTime.Now.ToString("MM") + "'  ");
            }
            catch
            {
                return 0;
            }
        }
        public int SumPayProductDay()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select sum(BillInfo.amount) from Bill, BillInfo Where Bill.billId = BillInfo.billId and cast (billDate as date) = cast(getdate() as date)");
            }
            catch
            {
                return 0;
            }
        }
        public double SumMoneyMonth()
        {
            try
            {
                return (double)DataProvider.Instance.ExecuteScalar("select sum(moneyPay) from UV_SumMoney where MONTH(dayPay) = '"+DateTime.Now.ToString("MM") + "' ");
            }
            catch
            {
                return 0;
            }
        }
        public double SumMoneyDay()
        {
            try
            {
                return (double)DataProvider.Instance.ExecuteScalar("select Sum(SUMMoney) from SumMoneyProduct, Bill where cast (Bill.billDate as date) = cast(getdate() as date) and SumMoneyProduct.billId = Bill.billId");
            }
            catch
            {
                return 0;
            }
        }
        public DataTable SumPayMoneyByDay()
        {
            string CurrentMonth = DateTime.Now.ToString("MM");
            return DataProvider.Instance.ExecuteQuery("USP_SumMoneyInDay @dayPa", new object[] { CurrentMonth });
        }
        public DataTable TotalPayProductByDay()
        {
            string CurrentMonth = DateTime.Now.ToString("MM");
            return DataProvider.Instance.ExecuteQuery("SELECT CAST(Bill.billDate AS DATE) AS Ngay, sum(cast(BillInfo.amount as int) ) as slsp FROM Bill, BillInfo where MONTH(Bill.billDate) = '" + CurrentMonth + "' group by CAST(Bill.billDate AS DATE)");
        }
    }
}
