using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHyperMarket.StorageManager.Controllers;
using NUnit.Framework;
using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.Common.StubModels;

namespace SmartHyperMarketTests.StorageManager.Controllers
{
    [TestFixture()]
    public class OrderControllerTests
    {
        [Test()]
        public void openOrderTestNormalCase()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("productId", "24"),
                new Input("confirmationCode", "LV7yx")
                );

            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        
        }

        [Test()]
        public void openOrderTestNoId()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("productId", ""),
                new Input("confirmationCode", "LV7yx")
                );

            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Order id can't be empty."), 0);
        
        }

        [Test()]
        public void openOrderTestNoId()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("productId", "24"),
                new Input("confirmationCode", "")
                );

            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Confirmation Code can't be empty."), 0);
        
        }


        [Test()]
        public void openOrderTestNoId()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("productId", "24"),
                new Input("confirmationCode", "sadas")
                );

            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Wrong Order ID/Confirmation Code Combination."), 0);

        }


        [Test()]
        public void showOrdersTestNormalCase()
        {
            
        }


        [Test()]
        public void updateOrderStateTestNormalCase1()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("State", "WAITING")
                
                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }

        [Test()]
        public void updateOrderStateTestNormalCase1()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("State", "PREPARING")

                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }

        [Test()]
        public void updateOrderStateTestNormalCase1()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("State", "READY")

                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }

        [Test()]
        public void updateOrderStateTestNormalCase1()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("State", "DONE")

                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }

        [Test()]
        public void updateOrderStateTestNormalCase1()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("State", "ALL")

                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }


        [Test()]
        public void updateOrderStateTestNoState()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("State", "")

                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Order state can't be empty."), 0);
        }


        [Test()]
        public void updateOrderStateTestNoState()
        {
            OrderController orderController = new OrderController();
            Response response = orderController.openOrder(
                new Input("State", "text")

                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Order state " + state.Value + " isn't acceptable."), 0);
        }




    
    
}
}