using Business.Abstract;
using DataAccess.Abstract;
using Models;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
         
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category, Expression<Func<Category, bool>> filter = null)
        { 
            _categoryDal.Delete(category, filter);
             
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category GetById(Expression<Func<Category, bool>> filter = null)
        { 
            return _categoryDal.Get(filter);
        }
        
        public void Update(Category category, Expression<Func<Category, bool>> filter = null)
        { 
            _categoryDal.Update(category, filter);
        }
    }
}
