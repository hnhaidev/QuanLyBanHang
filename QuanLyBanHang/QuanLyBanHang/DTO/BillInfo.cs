using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class BillInfo
    {
        private int billInfoId;
        private int billId;
        private int productId;
        private int amount;

        public int BillInfoId { get => billInfoId; set => billInfoId = value; }
        public int BillId { get => billId; set => billId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int Amount { get => amount; set => amount = value; }

        public BillInfo()
        {

        }
        public BillInfo(int _billInfoId, int _billId, int _productId, int _amount)
        {
            this.billInfoId = _billInfoId;
            this.billId = _billId;
            this.productId = _productId;
            this.amount = _amount;
        }
    }
}
