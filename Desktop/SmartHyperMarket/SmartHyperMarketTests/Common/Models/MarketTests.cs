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
        public class MarketMock : Market
        {
            public MarketMock() {}
        }
        [Test()]
        public void getInstanceTest()
        {
            Assert.IsInstanceOf<Market>(Market.getInstance());
        }
        [Test()]
        public void updateOfferTest()
        {
            Market market = new MarketMock();
            Offer offer = new Offer();
            offer.Id = "1";
            market.Offers.Add(offer);
            Assert.IsTrue(market.updateOffer(offer));
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
            MarketMock market = new MarketMock();
            Assert.IsNull(market.Orders);
            market.refreshOrders();
            Assert.IsNotNull(market.Orders);
        }
    }
}
