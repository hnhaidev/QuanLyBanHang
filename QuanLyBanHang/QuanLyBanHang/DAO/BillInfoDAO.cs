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
        public void DeleteBillInfo(int productId)
        {
            DataProvider.Instance.ExecuteNonQuery("Delete BillInfo where productId = " + productId);
        }
        public List<BillInfo> GetListBillInfo(int billId)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from BillInfo where billId = " + billId);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
        public DataTable ListBillById(int id)
        {
            return DataProvider.Instance.ExecuteQuery("USP_ListBillInfo @idBill ", new object[] { id });
        }
    }
}
