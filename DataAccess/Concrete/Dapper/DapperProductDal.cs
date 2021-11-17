using Dapper;
using DataAccess.Abstract;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class DapperProductDal : DapperGenericRepository<Product>, IProductDal
    {
        public List<Product> GetProductListByCategoryId(int categoryId)
        {
            using (var connection = DbConnect.Connection)
            {
                return connection.Query<Product>("GetAllProductsByCategoryId @CategoryId", new { CategoryId = categoryId }).ToList();               
            }
        }
    }
}
