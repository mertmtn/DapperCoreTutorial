using Models;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IProductService
    {        
        List<Product> GetAll();
        List<Product> GetProductListByCategoryId(int categoryId);
        void Add(Product product);
        void Update(Product product, Expression<Func<Product, bool>> filter=null);
        void Delete(Product product, Expression<Func<Product, bool>> filter = null);
        Product GetById(Expression<Func<Product, bool>> filter = null);
    }
}
