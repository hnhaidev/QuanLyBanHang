using System;
using System.Collections.Generic;
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
        private bool accountType;

        public Account(int _staffId, string _userName, string _passWord, bool _accountType)
        {
            this.staffId = _staffId;
            this.userName = _userName;
            this.passWord = _passWord;
            this.AccountType = _accountType;
        }

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public bool AccountType { get => accountType; set => accountType = value; }
        public int AccountCode { get => staffId; set => staffId = value; }
    }
}
