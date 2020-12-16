using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class Account
    {
        private int staffId;
        private string userName;
        private string passWord;
        private int accountType;

        public Account(int staffId, string userName, string passWord, int accountType)
        {
            this.StaffId = staffId;
            this.UserName = userName;
            this.PassWord = passWord;
            this.AccountType = accountType;
        }
        public Account(DataRow row)
        {
            this.StaffId = (int)row["staffId"];
            this.UserName = row["userName"].ToString();
            this.PassWord = row["passWord"].ToString();
            this.AccountType = (int)row["accountType"];
        }
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int AccountType { get => accountType; set => accountType = value; }
        public int StaffId { get => staffId; set => staffId = value; }
    }
}
