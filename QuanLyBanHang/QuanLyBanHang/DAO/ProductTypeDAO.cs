using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class ProductTypeDAO
    {
        private static ProductTypeDAO instance;

        public static ProductTypeDAO Instance 
        {
            get 
            {
                if (instance == null) instance = new ProductTypeDAO();
                return instance;
            }
            private set => instance = value;
        }
        private ProductTypeDAO()
        {

        }
        public List<ProductType> GetListProductType()
        {
            List<ProductType> list = new List<ProductType>();
            string query = "select * from ProductType";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ProductType productType = new ProductType(item);
                list.Add(productType);
            }

            return list;
        }
    }
}
