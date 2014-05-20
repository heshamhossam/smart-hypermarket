using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHyperMarket.DataEntryManager.Controllers;
using NUnit.Framework;
using SmartHyperMarket.Common.Controllers;
<<<<<<< HEAD
using SmartHyperMarket.Common.StubModels;
=======


>>>>>>> fb81b4ab29b73230c9784c41bc5f28d12fa10097
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
