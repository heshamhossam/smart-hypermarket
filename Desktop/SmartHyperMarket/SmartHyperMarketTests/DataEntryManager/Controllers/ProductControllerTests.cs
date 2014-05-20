using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHyperMarket.DataEntryManager.Controllers;
using NUnit.Framework;
using SmartHyperMarket.Common.Controllers;


namespace SmartHyperMarket.DataEntryManager.Controllers.Tests
{
    [TestFixture()]
    public class ProductControllerTests
    {
        [Test()]
        public void createProductTestNormalCase()
        {
            ProductController productController = new ProductController();
            Response response = productController.createProduct(
                new Input("name", "1"),
                new Input("barcode", "1"),
                new Input("price", "1"),
                new Input("categoryId", "1"),
                new Input("weight", "1"),
                new Input("description", "1")
                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);

        }


        [Test()]
        public void createProductTestNoName()
        {
            ProductController productController = new ProductController();
            Response response = productController.createProduct(
                new Input("name", ""),
                new Input("barcode", "1"),
                new Input("price", "1"),
                new Input("categoryId", "1"),
                new Input("weight", "1"),
                new Input("description", "1")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product Name can't be empty."), 0);

        }


        [Test()]
        public void createProductTestNoBarcode()
        {
            ProductController productController = new ProductController();
            Response response = productController.createProduct(
                new Input("name", "1"),
                new Input("barcode", ""),
                new Input("price", "1"),
                new Input("categoryId", "1"),
                new Input("weight", "1"),
                new Input("description", "1")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product Barcode can't be empty."), 0);

        }


        [Test()]
        public void createProductTestNoPrice()
        {
            ProductController productController = new ProductController();
            Response response = productController.createProduct(
                new Input("name", "1"),
                new Input("barcode", "1"),
                new Input("price", ""),
                new Input("categoryId", "1"),
                new Input("weight", "1"),
                new Input("description", "1")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product Price can't be empty."), 0);

        }


        [Test()]
        public void createProductTestNoCategory()
        {
            ProductController productController = new ProductController();
            Response response = productController.createProduct(
                new Input("name", "1"),
                new Input("barcode", "1"),
                new Input("price", "1"),
                new Input("categoryId", ""),
                new Input("weight", "1"),
                new Input("description", "1")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product Category can't be empty."), 0);

        }


        [Test()]
        public void createProductTestNoWeight()
        {
            ProductController productController = new ProductController();
            Response response = productController.createProduct(
                new Input("name", "1"),
                new Input("barcode", "1"),
                new Input("price", "1"),
                new Input("categoryId", "1"),
                new Input("weight", ""),
                new Input("description", "1")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product Weight can't be empty."), 0);

        }


        [Test()]
        public void createProductTestNoDescription()
        {
            ProductController productController = new ProductController();
            Response response = productController.createProduct(
                new Input("name", "1"),
                new Input("barcode", "1"),
                new Input("price", "1"),
                new Input("categoryId", "1"),
                new Input("weight", "1"),
                new Input("description", "")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product Description can't be empty."), 0);

        }


    }
}
