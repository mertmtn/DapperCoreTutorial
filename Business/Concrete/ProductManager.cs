using Business.Abstract;
using DataAccess.Abstract;
using Models;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        public void Add(Product product)
        {
            _productDal.Add(product);           
        }

       
        public void Update(Product product, Expression<Func<Product, bool>> filter = null)
        {          
            _productDal.Update(product, filter);
        }

        public void Delete(Product product, Expression<Func<Product, bool>> filter = null)
        {            
            _productDal.Delete(product, filter); 
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(Expression<Func<Product, bool>> filter = null)
        {
           
            return _productDal.Get(filter);
        }

        public List<Product> GetProductListByCategoryId(int categoryId)
        {
            return _productDal.GetProductListByCategoryId(categoryId);
        }
    }
}
