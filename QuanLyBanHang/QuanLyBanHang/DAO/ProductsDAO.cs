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

        public bool InsertProduct( string productName, int productTypeID, float productPrice, int productAmount)
        {
            string query = string.Format("insert Product ( productName , productTypeId , productPrice , productAmount ) " +
                "values ( N'{0}' , {1} , {2}, {3} )",productName, productTypeID, productPrice, productAmount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateProduct(int productId, string productName, int productTypeID, float productPrice, int productAmount)
        {
            string query = string.Format("update Product set productName = N'{1}', productTypeId = {2} , " +
                "productPrice = {3} , productAmount = {4} where productId = {0}", productId, productName, productTypeID, productPrice, productAmount);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteProduct(int productId)
        {
            string query = string.Format("delete Product where productId"+ productId);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Products> SearchProductByName(string productName)
        {
            List<Products> list = new List<Products>();
            string query = string.Format("select * from Product where dbo.fuConvertToUnsign1(productName) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", productName);
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
