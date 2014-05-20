using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHyperMarket.DataEntryManager.Controllers;
using SmartHyperMarket.Common.Controllers;
using NUnit.Framework;

namespace SmartHyperMarket.DataEntryManager.Controllers.Tests
{
    [TestFixture()]
    public class OfferControllerTests
    {
        [Test()]
        public void addProductToOfferTestNormalCase()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.addProductToOffer(
                new Input("productId", "1"),
                new Input("productQuantity", "1"));
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }
        [Test()]
        public void addProductToOfferTestEmptyID()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.addProductToOffer(
                new Input("productId", ""),
                new Input("productQuantity", "1"));
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product ID can't be empty."), 0);
        }
    }
}
