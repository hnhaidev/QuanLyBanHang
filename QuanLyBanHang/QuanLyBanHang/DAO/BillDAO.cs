using System;
using System.Collections.Generic;
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
    }
}
