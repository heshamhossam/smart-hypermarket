using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHyperMarket.StorageManager.Controllers;
using NUnit.Framework;
using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.Common.Models;
//using SmartHyperMarket.Common.StubModels;

namespace SmartHyperMarketTests.StorageManager.Controllers
{
    [TestFixture()]
    public class OrderControllerTests
    {
        [Test()]
        public void openOrderTestNoId()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("id", ""),
                new Input("confirmationCode", "LV7yx")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Order id can't be empty."), 0);
        
        }

        [Test()]
        public void openOrderTestNoConfirmation()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("id", "24"),
                new Input("confirmationCode", "")
                );

            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Confirmation Code can't be empty."), 0);
        }
    }
}