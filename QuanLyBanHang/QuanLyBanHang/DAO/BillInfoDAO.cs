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
            DataProvider.Instance.ExecuteNonQuery("proc USP_InsertBillInfo @billId , @productId , @amount ", new object[] { billId , productId , amount });
        }
        public void DeleteBillInfo(int productId)
        {
            DataProvider.Instance.ExecuteNonQuery("Delete BillInfo where productId = " + productId);
        }
        public List<BillInfo> GetListBillInfo(int productId)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from BillInfo where productId = " + productId);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }
    }
}
