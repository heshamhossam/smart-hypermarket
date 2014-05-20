using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHyperMarket.DataEntryManager.Controllers;
using NUnit.Framework;
using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.Common.StubModels;
namespace SmartHyperMarket.DataEntryManager.Controllers.Tests
{
    [TestFixture()]
    public class ProductControllerTests
    {

         [Test()]
        public void editProductTestNormalCase()
        {
            ProductController productcontroller = new ProductController();
            Product p = new Product();
            p.Name = "test";
            p.Barcode = "1";
            p.Price = 1.1f;
            Response response = productcontroller.editProduct(p,
                new Input("name", "test"),
                new Input("barcode", "1"),
                new Input("price", "1,1"));
             Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }

        [Test()]
         public void editProductTestEmptyName()
         {
             ProductController productcontroller = new ProductController();
             Product p = new Product();
             p.Name = "";
             p.Barcode = "1";
             p.Price = 1.1f;
             Response response = productcontroller.editProduct(p,
                 new Input("name", ""),
                new Input("price", "1.0"),
                new Input("barcode", "1")
                );
             Assert.AreEqual(response.State, ResponseState.FAIL);
             Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Please add the product name"), 0);
         }

        [Test()]
        public void editProductTestEmptyPrice()
        {
            ProductController productcontroller = new ProductController();
            Product p = new Product();
            p.Name = "test";
            p.Barcode = "1";
            p.Price = 0;
            Response response = productcontroller.editProduct(p,
                new Input("name", ""),
               new Input("price", ""),
               new Input("barcode", "1")
               );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Please add the product price"), 0);
        }


        [Test()]
        public void editProductTestEmptybarcode()
        {
            ProductController productcontroller = new ProductController();
            Product p = new Product();
            p.Name = "test";
            p.Barcode = "";
            p.Price = 1.1f;
            Response response = productcontroller.editProduct(p,
                new Input("name", ""),
               new Input("price", "1.0"),
               new Input("barcode", "")
               );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Please add the product barcode"), 0);
        }



        [Test()]
        public void deleteProductTestNormalCase()
        {
            ProductController productcontroller = new ProductController();
            Product p = new Product();
            p.Name = "test";
            p.Barcode = "1";
            p.Price = 1.1f;
            Response response = productcontroller.deleteProduct(p);
            Assert.AreEqual(response.State, ResponseState.SUCCESS);

        }



        [Test()]
        public void createProductTestNormalCase()
        {
            
        }
    }
}
