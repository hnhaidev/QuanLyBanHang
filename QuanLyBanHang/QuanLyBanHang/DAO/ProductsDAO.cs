using QuanLyBanHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO
{
    public class ProductsDAO
    {
        private static ProductsDAO instance;

        public static ProductsDAO Instance 
        { 
            get
            {
                if (instance == null) instance = new ProductsDAO();
                return instance;
            }
            private set => instance = value; 
        }
        public ProductsDAO()
        {

        }
        public DataTable ListProduct()
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_Product");
        }
        public List<Products> GetListProduct(int id)
        {
            List<Products> list = new List<Products>();
            string query = "select * from Product where productTypeId =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Products products = new Products(item);
                list.Add(products);
            }

            return list;
        }
    }
}
