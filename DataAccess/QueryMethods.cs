using Dapper;
using Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public static class QueryMethods
    {
        public static List<Product> ProductCategory()
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"SELECT * FROM dbo.Categories
                    INNER JOIN dbo.Products
                    ON dbo.Categories.CategoryID = dbo.Products.CategoryID";

                var list = connection.Query<Product, Category, Product>(query, (urun, kat) =>
                {
                    urun.CategoryId = kat.CategoryId;
                    return urun;
                }, splitOn: "CategoryID").ToList();

                return list;
            }
        }

        public static List<Order> OrderOrderDetails()
        {
            using (var connection = DbConnect.Connection)
            {
                var query = "SELECT * FROM dbo.Products INNER JOIN  dbo.[Order Details] ON dbo.Products.ProductID = dbo.[Order Details].ProductID";

                var list = connection.Query<Order, OrderDetail, Order>(query, (siparis, siparisDetay) =>
                {
                    siparis.OrderDetails = siparisDetay;
                    return siparis;
                }, splitOn: "ProductID").ToList();

                return list;
            }
        }

        public static List<dynamic> AnonymusList()
        {
            using (var connection = DbConnect.Connection)
            {
                var urunListesi = connection.Query("SELECT * FROM Products").ToList();

                return urunListesi;
            }
        }

        public static ArrayList SelectMultipleQueries()
        {
            using (var connection = DbConnect.Connection)
            {
                var sql = "Select * From Products; Select * From Categories";

                SqlMapper.GridReader multiQuery = connection.QueryMultiple(sql);
                var productList = multiQuery.Read<Product>().ToList();
                var categoryList = multiQuery.Read<Category>().ToList();

                return new ArrayList() { productList, categoryList };
            }
        }

        public static List<Product> GetAllProducts()
        {
            using (var connection = DbConnect.Connection)
            {
                var urunListesi = connection.Query<Product>("SELECT * FROM Products").ToList();

                return urunListesi;
            }
        }
        public static List<Product> SPGetAllProducts()
        {
            using (var connection = DbConnect.Connection)
            {
                var query = "GetAllProducts";

                var urunListesi = connection.Query<Product>(query, commandType: System.Data.CommandType.StoredProcedure).ToList();

                return urunListesi;
            }
        }

        public static Product GetProductById(int id)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = "Select * From Products Where ProductId=@ProductId";

                return connection.QueryFirstOrDefault<Product>(query, new { ProductId = id });
                //return connection.QueryFirst<Product>(query, new { ProductId = id });
                //return connection.QuerySingle<Product>(query, new { ProductId = id });
                //return connection.QuerySingleOrDefault<Product>(query, new { ProductId = id });
            }
        }

        public static Product SPGetProductById(int id)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = "GetProductById";

                return connection.QueryFirstOrDefault<Product>(query, new { id = id }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
