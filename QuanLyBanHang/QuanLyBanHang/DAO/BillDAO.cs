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
        public void InsertBill(int staffId, string clientPhone)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBill @staffId , @clientPhone ", new object[] { staffId, clientPhone});
        }
    }
}
