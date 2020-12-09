using System;
using System.Collections.Generic;
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
        private string productType;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public float ProductPrice { get => productPrice; set => productPrice = value; }
        public string ProductType { get => productType; set => productType = value; }

        public Products()
        {

        }
        public Products(int _productId, string _productName, float _productPrice, string _productType)
        {
            this.productId = _productId;
            this.productName = _productName;
            this.productPrice = _productPrice;
            this.productType = _productType;
        }
    }
}
