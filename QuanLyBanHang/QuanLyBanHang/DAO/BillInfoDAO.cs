using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        {
            get
            {
                if (instance == null) instance = new BillInfoDAO();
                return instance;
            }
            private set => instance = value; 
        }
        private BillInfoDAO() { }
        public void InsertBillInfo(int billId, int productId, int amount)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @billId , @productId , @amount ", new object[] { billId , productId , amount });
        }
        public DataTable ListBillById(int id)
        {
            return DataProvider.Instance.ExecuteQuery("USP_ListBillInfo @idBill ", new object[] { id });
        }
    }
}
