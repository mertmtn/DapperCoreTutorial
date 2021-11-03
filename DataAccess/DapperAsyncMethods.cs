using Dapper;
using Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DapperAsyncMethods
    {
        #region Execute Methods
        public static async Task<DataTable> GetAllProductsDataTableAsync()
        {
            using (var connection = DbConnect.Connection)
            {
                var reader = await connection.ExecuteReaderAsync("SELECT * FROM Products");
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
        }
        public static async Task<string> GetProductsNameByIdAsync(int productId)
        {
            using (var connection = DbConnect.Connection)
            {
                return await connection.ExecuteScalarAsync<string>("SELECT ProductName FROM Products WHERE ProductId = @ProductId;", new { ProductId = productId });
            }
        }
        public static async Task<int> AddOneCategoryAsync(Category category)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"INSERT INTO [dbo].[Categories]([CategoryName],[Description])
                                 VALUES (@CategoryName, @Description)";

                return await connection.ExecuteAsync(query, new { CategoryName = category.CategoryName, Description = category.Description });
            }
        }

        #endregion

        #region Query Methods
        public static async Task<IEnumerable<Product>> ProductCategoryAsync()
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"SELECT * FROM dbo.Categories
                    INNER JOIN dbo.Products
                    ON dbo.Categories.CategoryID = dbo.Products.CategoryID";

                var list = connection.QueryAsync<Product, Category, Product>(query, (urun, kat) =>
                {
                    urun.CategoryId = kat.CategoryId;
                    return urun;
                }, splitOn: "CategoryID");

                return await list;
            }
        }

        public static async Task<ArrayList> SelectMultipleQueriesAsync()
        {
            using (var connection = DbConnect.Connection)
            {
                var sql = @"Select * From Products; 
                            Select * From Categories";

                SqlMapper.GridReader multiQuery = await connection.QueryMultipleAsync(sql);
                
                var productList = multiQuery.Read<Product>().ToList();
                var categoryList = multiQuery.Read<Category>().ToList();

                return new ArrayList() { productList, categoryList };
            }
        }

        public static async Task<Product> GetProductByIdAsync(int id)
        {
            using (var connection = DbConnect.Connection)
            {
                var query = @"Select * From Products Where ProductId=@ProductId";
                return await connection.QueryFirstOrDefaultAsync<Product>(query, new { ProductId = id });

                //Other Query methods.
                //return await connection.QueryFirstAsync<Product>(query, new { ProductId = id });
                //return await connection.QuerySingleAsync<Product>(query, new { ProductId = id });
                //return await connection.QuerySingleOrDefaultAsync<Product>(query, new { ProductId = id });
            }
        }

        #endregion
    }
}
