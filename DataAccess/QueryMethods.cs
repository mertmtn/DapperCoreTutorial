using Dapper;
using Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
                var query = @"SELECT * FROM dbo.Products INNER JOIN  dbo.[Order Details] ON dbo.Products.ProductID = dbo.[Order Details].ProductID";

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
            /*
             * Buffered Parametresi: Arabelleğe alınmış bir sorgu tüm okuyucuyu bir kerede döndürür.
             * Bu çoğu senaryoda idealdir.
                https://dapper-tutorial.net/buffered
                Arabelleğe alınmamış bir sorgu akış olarak eşdeğerdir. Nesneleri yalnızca talep üzerine yüklersiniz. 
                Bu, bellek kullanımını azaltmak için çok büyük bir sorgu için yararlı olabilir.*/
            var query = "GetAllProducts";

            using (var connection = DbConnect.Connection)
            {
                var productList = connection.Query<Product>(query, buffered: false).ToList();
                return productList;
            } 
        }
        public static Product GetProductById(int id)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = "Select * From Products Where ProductId=@ProductId";

                return connection.QueryFirstOrDefault<Product>(query, new { ProductId = id });

                //Diğer Query metotları da aşağıdaki gibidir.
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
        public static List<Product> GetProductsByIdList(params int [] idList)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = "Select * From Products Where ProductId IN @ProductIdList";
               
                return connection.Query<Product>(query, new { ProductIdList = idList }).ToList();               
            }
        }

        public static int GetLastInsertedCategoryId(Category kategori)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = "spAddCategoryGetCategoryId";

                var parametreList = new DynamicParameters();

                parametreList.Add("@Description", dbType: DbType.String, value: kategori.Description, direction: ParameterDirection.Input);
                parametreList.Add("@CategoryName", dbType: DbType.String, value: kategori.CategoryName, direction: ParameterDirection.Input);
                parametreList.Add("@CategoryId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Query<int>(query, parametreList, commandType: CommandType.StoredProcedure);
                return parametreList.Get<int>("CategoryId");
            }
        }
    }
}
