using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class Products
    {
        private int productId;
        private string productName;
        private float productPrice;
        private int productTypeId;
        private int productAmount;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public float ProductPrice { get => productPrice; set => productPrice = value; }
        public int ProductTypeId { get => productTypeId; set => productTypeId = value; }
        public int ProductAmount { get => productAmount; set => productAmount = value; }

        public Products()
        {

        }
        public Products(int _productId, string _productName, float _productPrice, int _productTypeId, int _productAmount)
        {
            this.ProductId = _productId;
            this.ProductName = _productName;
            this.ProductPrice = _productPrice;
            this.ProductTypeId = _productTypeId;
            this.ProductAmount = _productAmount;
        }
        public Products(DataRow row)
        {
            this.productId = (int)row["productId"];
            this.productName = row["productName"].ToString();
            this.productPrice = (float)Convert.ToDouble(row["productPrice"].ToString());
            this.ProductTypeId = (int)row["productTypeId"];
            this.ProductAmount = (int)row["productAmount"];
        }
    }
}
