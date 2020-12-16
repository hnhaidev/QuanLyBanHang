using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class BillInfo
    {
        private int billId;
        private int productId;
        private int amount;
        public int BillId { get => billId; set => billId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int Amount { get => amount; set => amount = value; }

        public BillInfo()
        {

        }
        public BillInfo( int billId, int productId, int amount)
        {
            this.BillId = billId;
            this.ProductId = productId;
            this.Amount = amount;
        }
        public BillInfo(DataRow row)
        {
            this.BillId = (int)row["billId"];
            this.ProductId = (int)row["productId"];
            this.Amount = (int)row["amount"];
        }
    }
}
