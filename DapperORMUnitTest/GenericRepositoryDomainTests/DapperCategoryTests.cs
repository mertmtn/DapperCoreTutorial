using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace DapperORMUnitTest.GenericRepositoryDomainTests
{
    [TestClass]
    public class DapperCategoryTests
    {
        public ICategoryService categoryService;
        
        public DapperCategoryTests()
        {
            categoryService = new CategoryManager(new DapperCategoryDal());
        }

        [TestMethod]
        public void Should_Return_AllCategories_Successful()
        {
            var result = categoryService.GetAll();
        }

        [TestMethod]
        public void Should_Return_CategoryById_Successful()
        {
            var categoryId = 3;
            var result = categoryService.GetById(c=>c.CategoryId==categoryId);
        }

        [TestMethod]
        public void Should_Add_Category_Successful()
        {
            var category = new Category
            {
                CategoryName = "Spor Ekipman",
                Description = "Spor Ekipmanları Kategorisi"
            };
            categoryService.Add(category);
        }

        [TestMethod]
        public void Should_Update_Category_Successful()
        {
            var category = new Category
            {
                CategoryId = 32,
                CategoryName = "Spor",
                Description = "Spor Desc"
            };
            categoryService.Update(category);
        }

        [TestMethod]
        public void Should_Delete_Category_Successful()
        {
            var category = new Category
            {
                CategoryId = 32,
                CategoryName = "Spor Ekipman",
                Description = "Spor Ekipmanları Kategorisi"
            };
            categoryService.Delete(category);
        }
    }
}
