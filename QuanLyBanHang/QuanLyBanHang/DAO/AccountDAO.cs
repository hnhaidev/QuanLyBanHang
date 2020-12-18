    using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value; 
        }
        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string hashPass = MaHoaMD5(passWord);
            string query = "USP_Login @userName , @passWord ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hashPass });
            return result.Rows.Count > 0;
        }

        public string MaHoaMD5(string input)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(input);
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hashPass = "";
            for (int i = 0; i < hash.Length; i++)
            {
                hashPass += hash[i].ToString();
            }
            return hashPass;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_Account");
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public bool InserAccount(int staffId, string userName, string passWord, int accountType)
        {
            string query = string.Format("insert Account ( staffId , userName , passWord , accountType ) " +
                "values ( N'{0}' , N'{1}' , N'{2}' , N'{3}' )", staffId , userName , passWord, accountType );
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string userName)
        {
            string query = string.Format("delete Account where userName = '{0}'", userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(int staffId, string userName, string passWord, int accountType)
        {
            string hashPass = MaHoaMD5(passWord);
            string query = string.Format("update Account set staffId = {1} , passWord = '{2}' , accountType = {3} where userName = '{0}'", userName , staffId , hashPass, accountType);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable GetListAccountByName(string name)
        {
            string query = string.Format("exec USP_SearchAccount N'{0}'", name);
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
