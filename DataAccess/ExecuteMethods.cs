using Dapper;
using Models;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class ExecuteMethods
    {
        public static DataTable GetAllProductsDataTable()
        {
            using (var connection = DbConnect.Connection)
            {
                var reader = connection.ExecuteReader("SELECT * FROM Products");
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public static DataTable GetAllProductsByCategoryIdDataTable(int categoryId)
        {
            using (var connection = DbConnect.Connection)
            {
                var reader = connection.ExecuteReader("GetAllProductsByCategoryId @CategoryId", new { CategoryId = categoryId });
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }

        public static string GetProductsNameById(int productId)
        {
            using (var connection = DbConnect.Connection)
            {
                return connection.ExecuteScalar<string>("SELECT ProductName FROM Products WHERE ProductId = @ProductId;", new { ProductId = productId });
            }
        }

        public static string GetProductsNameObjectById(int productId)
        {
            using (var connection = DbConnect.Connection)
            {
                return connection.ExecuteScalar("SELECT ProductName FROM Products WHERE ProductId = @ProductId;", new { ProductId = productId }).ToString();
            }
        }

        public static int AddOneCategory(Category kategori)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"INSERT INTO [dbo].[Categories]([CategoryName],[Description]) VALUES (@CategoryName, @Description)";
                return connection.Execute(query, new { CategoryName = kategori.CategoryName, Description = kategori.Description });
            }
        }

        public static int UpdateCategory(Category kategori, int id)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"UPDATE [dbo].[Categories] SET [CategoryName] =@CategoryName,[Description] = @Description WHERE CategoryId=@CategoryId";
                return connection.Execute(query, new { CategoryName = kategori.CategoryName, Description = kategori.Description, CategoryId = id });
            }
        }

        public static int DeleteCategory(int id)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"DELETE FROM [dbo].[Categories] WHERE CategoryId=@CategoryId";
                return connection.Execute(query, new { CategoryId = id });
            }
        }

        public static int DeleteCategory(List<int> idList)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"DELETE FROM [dbo].[Categories] WHERE CategoryId IN @CategoryId";
                return connection.Execute(query, new { CategoryId = idList });
            }
        }

        public static int SPAddOneCategory(Category kategori)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = "AddCategory";
                return connection.Execute(query, new { CategoryName = kategori.CategoryName, Description = kategori.Description }, commandType: CommandType.StoredProcedure);
            }
        } 

        public static int AddManyCategories(List<Product> urunListesi)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"INSERT INTO [dbo].[Products]([ProductName],[UnitPrice],[UnitsInStock],CategoryID) 
                    VALUES (@ProductName,@UnitPrice,@UnitsInStock,@CategoryID)";

                foreach (var urun in urunListesi)
                {
                    connection.Execute(query, new { ProductName = urun.ProductName, UnitPrice = urun.UnitPrice, UnitsInStock = urun.UnitsInStock, CategoryID = urun.CategoryId });
                }
                return urunListesi.Count;
            }
        }
    }
}
