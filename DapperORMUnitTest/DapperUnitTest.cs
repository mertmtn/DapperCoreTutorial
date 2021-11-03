using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORMUnitTest
{
    [TestClass]
    public class DapperUnitTest
    {
        [TestMethod]
        public async Task Should_Return_DataTable_GetProductNameById_Async()
        {
            var productId = 5;
            var result = await DapperAsyncMethods.GetProductsNameByIdAsync(productId);
            Assert.IsNotNull(result, "Result is null");
        }


        [TestMethod]
        public async Task Should_Return_JoinListOfProductCategory_Async()
        {
            var result = (await DapperAsyncMethods.ProductCategoryAsync()).ToList();
            Assert.AreNotEqual(0, result);
        }


        [TestMethod]
        public async Task Should_Success_Insert_Category_Async()
        {
            var category = new Category()
            {
                CategoryName = "Camp",
                Description = "Camp Description",
            };
            var affectedRow = await DapperAsyncMethods.AddOneCategoryAsync(category);
            Assert.AreEqual(1, affectedRow);
        }

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
        public void Should_Return_DataTable_GetProductsByCategoryIdList()
        {
            int[] productIdList = { 5, 6, 7 };
            var result = QueryMethods.GetProductsByIdList(productIdList);
            Assert.AreNotEqual(0, result.Count);
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
