using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SmartHyperMarket.Common.Models;
using SmartHyperMarket.Common.StubModels;
using NUnit.Framework;

namespace SmartHyperMarket.Common.Models.Tests
{
    [TestFixture()]
    public class MarketTests
    {
        [Test()]
        public void getInstanceTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void getInstanceTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void updateOfferTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void deleteOfferTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void addOfferTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void addProductTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void editProductTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void deleteProductTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void refreshOrdersTest()
        {
            Market market = Market.getInstance();
            Assert.AreEqual(0, market.Orders.Count);
            market.refreshOrders();
            //Assert.AreNotEqual(0, testMarket.Orders.Count);
        }
    }
}
