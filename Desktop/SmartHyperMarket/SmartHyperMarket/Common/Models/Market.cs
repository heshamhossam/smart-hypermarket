using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.Models
{
    public delegate void OnModelChange();

    public class Market : IMarket
    {
        public OnModelChange onProductsChangeHandler;
        private OnModelChange onOffersChangeHandler;

        private static Market MyMarket;
        private List<Product> ProductList = new List<Product>();
        private List<Category> CategoryList = new List<Category>();
        private List<Order> orders = new List<Order>();
        private List<Employee> employees = new List<Employee>();
        private List<Offer> offers = new List<Offer>();

        private Market()
        {
            CategoryList = Category.all(this);
            orders = Order.all(this, Order.ALL);
            offers = Offer.all(this);
            LoadProducts();
        }

        /// <summary>
        /// get instance of the static object market
        /// </summary>
        /// <returns>market object</returns>
        /// 
        public static Market getInstance()
        {
            if (MyMarket == null)
            {
                MyMarket = new Market();
            }

            return MyMarket;
        }

        public List<Category> Categories
        {
            get
            {
                return CategoryList;
            }

        }

        public List<Product> Products
        {
            get
            {
                return ProductList;
            }

        }

        public List<Order> Orders
        {
            get
            {
                return orders;
            }
        }

        public List<Employee> Employees
        {
            get { return employees; }
        }

        public List<Offer> Offers
        {
            get { return offers; }
        }

        public int Id
        {
            get { return 1; }

        }

        public OnModelChange OnOffersChange
        {
            set { onOffersChangeHandler = value; }
        }

        public bool editOffer(Offer offer)
        {
            //search for offers in offers
            //if found update it with the new offer in the param and return true and fire the onofferchange event if not null
            //else return false
            if (offers.Exists(o=> o.id == offer.id))
            {
                offer.update();
                offers[offers.FindIndex(ind => ind.id == offer.id)] = offer;
                onOffersChangeHandler();
                return true;
            }
            else
            return false;
        }

        public bool deleteOffer(Offer offer)
        {
            if (offers.Exists(o => o.id == offer.id))
            {
                int temp = offers.IndexOf(offers.Single(o => o.id == offer.id));
                offers.RemoveAt(temp);
                offer.delete();
                onOffersChangeHandler();
                return true;
            }
            else
                return false;
        }

        public bool addOffer(Offer offer)
        {
            if (offers.Exists(o => o.id == offer.id))
                return false;
            else
            {
                offer.save();
                offers.Add(offer);
                return true;
            }
        }


        private void LoadProducts()
        {
            
            for (int i = 0; i < Categories.Count; i++)
            {
                foreach (var product in Categories[i].Products)
                {
                    product.Category_id = Categories[i].Id;
                    product.Market = this;
                    ProductList.Add(product);
                }
            }

        }

        public void refreshOrders()
        {
            orders = Order.all(MyMarket, Order.ALL);
        }
    }
}
