using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperORMUnitTest.GenericRepositoryDomains
{
    [TestClass]
    public class DapperProductTests
    {
        public  IProductService productService;
        public IProductDal productDal;
        public DapperProductTests()
        {           
            productService = new ProductManager(new DapperProductDal());
        }

        [TestMethod]
        public void Should_Return_AllProducts_Successful()
        {
           var result = productService.GetAll();            
        }

        [TestMethod]
        public void Should_Return_AllProducts_ByCategoryId_Successful()
        {
            var categoryId = 4;
            var result = productService.GetProductListByCategoryId(categoryId);
        }


        [TestMethod]
        public void Should_Return_SingleProduct_ById_Successful()
        {
            var result = productService.GetById(p=>p.ProductId==500);
        }
    }
}
