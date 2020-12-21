using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance 
        {
            get
            {
                if (instance == null) instance = new StaffDAO();
                return instance;
            }
            private set => instance = value; 
        }

        public DataTable GetListStaff()
        {
            return DataProvider.Instance.ExecuteQuery("USP_ListStaff");
        }
        public bool InsertStaff(string staffName, DateTime dateOfBirth, string address, string phoneNumber, bool gender)
        {
            string query = "USP_InsertStaff @staffName , @dateOfBirth , @address , @phoneNumber , @gender ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { staffName, dateOfBirth , address, phoneNumber , gender });
            return result > 0;
        }
        public bool UpdateStaff(string staffName, DateTime dateOfBirth, string address, string phoneNumber, bool gender)
        {
            string query = "USP_UpdateStaff @staffName , @dateOfBirth , @address , @phoneNumber , @gender ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { staffName, dateOfBirth, address, phoneNumber, gender });
            return result > 0;
        }
        public bool DeleteStaff(int id)
        {
            string query = "Delete Staff where staffId = " + id;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable SearchStaffByName(string staffName)
        {
            string query = string.Format("USP_SearchStaffByName @staffName");
            return DataProvider.Instance.ExecuteQuery(query, new object[] { staffName });
        }
    }
}
