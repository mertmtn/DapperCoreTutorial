using Models;
using System.Linq.Expressions;
namespace Business.Abstract
{
    public interface ICategoryService
    { 
        List<Category> GetAll();
        void Add(Category category);
        void Update(Category category, Expression<Func<Category, bool>> filter = null);
        void Delete(Category category, Expression<Func<Category, bool>> filter = null);
        Category GetById(Expression<Func<Category, bool>> filter = null);
    }
}
