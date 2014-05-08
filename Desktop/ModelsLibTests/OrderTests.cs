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
            List<Order> ret = Order.LoadOrders(Market.getInstance(), Order.ALL, "");
            //Assert
            Assert.AreEqual("0", ret[0].Id);
        }

        [Test()]
        public void updateTest()
        {
            Order order = new Order();
            order.update("");
        }
    }
}
