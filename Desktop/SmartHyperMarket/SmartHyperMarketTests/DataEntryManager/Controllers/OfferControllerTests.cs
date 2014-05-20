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
                new Input("productQuantity", "1")
                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }
        [Test()]
        public void addProductToOfferTestEmptyID()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.addProductToOffer(
                new Input("productId", ""),
                new Input("productQuantity", "1")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product ID can't be empty."), 0);
        }
        [Test()]
        public void addProductToOfferTestEmptyQuantity()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.addProductToOffer(
                new Input("productId", "1"),
                new Input("productQuantity", "")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Product quantity can't be empty."), 0);
        }
        [Test()]
        public void addProductToOfferTestNonNumQuantity()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.addProductToOffer(
                new Input("productId", "1"),
                new Input("productQuantity", "a")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Quantity do not represent integer value."), 0);
        }
        [Test()]
        public void createOfferTestNormalCase()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.createOffer(
                new Input("name", "test"),
                new Input("price", "1.0"),
                new Input("teaser", "test")
                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }
        [Test()]
        public void createOfferTestEmptyName()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.createOffer(
                new Input("name", ""),
                new Input("price", "1.0"),
                new Input("teaser", "test")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Offer name can't be empty."), 0);
        }
        [Test()]
        public void createOfferTestEmptyPrice()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.createOffer(
                new Input("name", "test"),
                new Input("price", ""),
                new Input("teaser", "test")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Offer price can't be empty."), 0);
        }
        [Test()]
        public void createOfferTestEmptyTeaser()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.createOffer(
                new Input("name", "test"),
                new Input("price", "1.0"),
                new Input("teaser", "")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Offer teaser can't be empty."), 0);
        }
        [Test()]
        public void editOfferTestNormalCase()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.editOffer(
                new Input("name", "test"),
                new Input("price", "1.0"),
                new Input("teaser", "test")
                );
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }
        [Test()]
        public void editOfferTestEmptyName()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.editOffer(
                new Input("name", ""),
                new Input("price", "1.0"),
                new Input("teaser", "test")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Offer name can't be empty."), 0);
        }
        [Test()]
        public void editOfferTestEmptyPrice()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.editOffer(
                new Input("name", "test"),
                new Input("price", ""),
                new Input("teaser", "test")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Offer price can't be empty."), 0);
        }
        [Test()]
        public void editOfferTestEmptyTeaser()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.editOffer(
                new Input("name", "test"),
                new Input("price", "1.0"),
                new Input("teaser", "")
                );
            Assert.AreEqual(response.State, ResponseState.FAIL);
            Assert.Greater(response.Errors.Count(error => error.ErrorMessage == "Offer teaser can't be empty."), 0);
        }
        [Test()]
        public void deleteOfferTestNormalCase()
        {
            OfferController offercontroller = new OfferController();
            Response response = offercontroller.deleteOffer();
            Assert.AreEqual(response.State, ResponseState.SUCCESS);
        }
    }
}
