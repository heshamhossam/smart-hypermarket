using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageManager.Models;
using DataEntryManager;
using NUnit.Framework;
namespace StorageManager.Models.Tests
{
    [TestFixture()]
    public class OrderTests
    {
        [Test()]
        public void LoadOrdersTest()
        {
            //Arrange
            List<Order> ret = Order.LoadOrders(Market.getInstance(), Order.ALL, "http://zonlinegamescom.ipage.com/smarthypermarket/public/orders/retrieve?market_id=1&filter=WAITING");
            //Assert
            Assert.AreEqual("24", ret[0].Id);
        }

        [Test()]
        public void updateTest()
        {
            Order order = new Order();
            order.update("http://zonlinegamescom.ipage.com/smarthypermarket/public/mocks/true‎");
        }
    }
}
