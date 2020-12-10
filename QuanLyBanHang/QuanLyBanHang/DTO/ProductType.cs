using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class ProductType
    {
        private int productTypeId;
        private string productTypeName;

        public ProductType()
        {

        }
        public ProductType(int _productTypeId, string _productTypeName)
        {
            this.productTypeId = _productTypeId;
            this.productTypeName = _productTypeName;
        }
        public ProductType(DataRow row)
        {
            this.productTypeId = (int)row["productTypeId"];
            this.productTypeName = row["productTypeName"].ToString(); // No lay tu CSDL
        }
        public int ProductTypeId { get => productTypeId; set => productTypeId = value; }
        public string ProductTypeName { get => productTypeName; set => productTypeName = value; }
    }
}
