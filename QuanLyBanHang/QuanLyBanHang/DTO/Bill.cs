using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class Bill
    {
        private int billId;
        private int clientId;
        private int staffId;
        private DateTime billDate;
        private float sumMoney;

        public int BillId { get => billId; set => billId = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public int StaffId { get => staffId; set => staffId = value; }
        public DateTime BillDate { get => billDate; set => billDate = value; }
        public float SumMoney { get => sumMoney; set => sumMoney = value; }

        private Bill() { }
        public Bill(int _billId, int _clientId, int _staffId, DateTime _billDate, float _sumMoney)
        {
            this.billId = _billId;
            this.clientId = _clientId;
            this.staffId = _staffId;
            this.billDate = _billDate;
            this.sumMoney = _sumMoney;
        }
    }
}
