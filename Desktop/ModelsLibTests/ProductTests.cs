using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryManager;
using NUnit.Framework;
namespace DataEntryManager.Tests
{
    [TestFixture()]
    public class ProductTests
    {
        [Test()]
        public void ProductTest()
        {
            Product product = new Product();
            Assert.IsNotNull(product);
        }

        [Test()]
        public void ProductTest1()
        {
            Product product = new Product("test", "test", 1, "test", "test", "test");
            Assert.AreEqual(product.Name, "test");
            Assert.AreEqual(product.Barcode, "test");
            Assert.AreEqual(product.Price, 1);
            Assert.AreEqual(product.Category_id, "test");
            Assert.AreEqual(product.Weight, "test");
            Assert.AreEqual(product.Description, "test");
        }

        [Test()]
        public void updateTest()
        {
            //Arrange
            Product Test_Prod = new Product("pepsi test", "123456789", 6, "1", "1", "desc");
            bool ret = Test_Prod.update("http://zonlinegamescom.ipage.com/smarthypermarket/public/mocks/true‎");
            //Assert
            Assert.IsTrue(ret);
        }


        [Test()]
        public void deleteTest()
        {
            Product product = new Product();
            bool ret = product.delete(new Market(), "http://zonlinegamescom.ipage.com/smarthypermarket/public/mocks/true‎");
            Assert.IsTrue(ret);
        }

        [Test()]
        public void saveTest()
        {
            Product product = new Product();
            Product ret = product.save(new Market(), "http://zonlinegamescom.ipage.com/smarthypermarket/public/mocks/true‎");
            Assert.IsNotNull(ret);
        }
    }
}
