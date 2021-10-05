using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace DapperORMUnitTest
{
    [TestClass]
    public class DapperUnitTest
    {
        [TestMethod]
        public void Should_Return_JoinListOfProductCategory()           
        {            
            var result = QueryMethods.ProductCategory();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void Should_Return_DataTable_ProductList()
        {
            var result = ExecuteMethods.GetAllProductsDataTable();
            Assert.AreNotEqual(0, result.Rows.Count);
        }

        [TestMethod]
        public void Should_Return_DataTable_GetProductNameById()
        {
            var productId = 5;
            var result = ExecuteMethods.GetProductsNameById(productId);
            Assert.IsNotNull(result,"Result is null");
        }

        [TestMethod]
        public void Should_Return_DataTable_GetProductsByCategoryId()
        {
            var categoryId = 5;
            var result = ExecuteMethods.GetAllProductsByCategoryIdDataTable(categoryId);
            Assert.AreNotEqual(0, result.Rows.Count);
        }

        [TestMethod]
        public void Should_Return_CategoryId_GreaterThan_Zero_GetLastInsertedCategoryId()
        {
            var category = new Category
            {
                CategoryName = "Automobile",
                Description = "Description for Automobile"
            };

            category.CategoryId = ExecuteMethods.GetLastInsertedCategoryId(category);
            Assert.IsTrue(category.CategoryId>0);
        }
    }
}
