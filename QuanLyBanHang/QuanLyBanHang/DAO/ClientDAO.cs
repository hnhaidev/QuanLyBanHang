using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class ClientDAO
    {
        private static ClientDAO instance;

        public static ClientDAO Instance 
        {
            get 
            {
                if (instance == null) instance = new ClientDAO();
                return instance; 
            }
            private set => instance = value; 
        }
        private ClientDAO() { }
        public bool InsertClient(string phoneNumber, string clientName, string address)
        {
            string query = string.Format("insert Client ( phoneNumber , clientName , address) values (N'{0}', N'{1}', N'{2}')", phoneNumber, clientName, address);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateClient()
        {
            string query = "";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Client> SearchClientByPhone(string phoneNumber)
        {
            List<Client> list = new List<Client>();
            string query = string.Format("Select * from Client where phoneNumber = '" + phoneNumber + "'");
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Client client = new Client(item);
                list.Add(client);
            }
            return list;
        }
    }
}
