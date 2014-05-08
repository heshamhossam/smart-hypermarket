using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryManager;
using NUnit.Framework;
using System.Runtime.Serialization;
namespace DataEntryManager.Tests
{
    [TestFixture()]
    public class MarketTests
    {
        [Test()]
        public void getInstanceTest()
        {
            Market testMarket = Market.getInstance();
            Assert.IsInstanceOf(typeof(Market), testMarket);
        }

        [Test()]
        public void refreshOrdersTest()
        {
            Market testMarket = new Market(true);
            Assert.AreEqual(0, testMarket.Orders.Count);
            testMarket.refreshOrders();
            //Assert.AreNotEqual(0, testMarket.Orders.Count);
        }
    }
}
