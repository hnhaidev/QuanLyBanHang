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
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetListProduct @productTypeId ", new object[] { id });
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
            string query = string.Format("delete Product where productId = {0}", productId);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable SearchProductByName(string productName)
        {
            string query = string.Format("USP_SearchProductByName @productName");
            return DataProvider.Instance.ExecuteQuery(query, new object[] { productName });
        }
        public bool UpdateProductAmount(int productId, int amount)
        {
            string query = string.Format("Update Product set productAmount = productAmount - {0} where productId = {1} ", amount, productId);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public int SumProduct()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select SUM(productAmount) from Product");
            }
            catch
            {
                return 0;
            }
        }
        public DataTable ProductAlmostOfStock()
        {
            return DataProvider.Instance.ExecuteQuery("select productName as Ten,productAmount as SL from Product where  productAmount <= 25");
        }
    }
}
