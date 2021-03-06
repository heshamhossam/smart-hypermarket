﻿using Newtonsoft.Json;
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

        protected Market()
        {
            CategoryList = Category.all(this);
            orders = Order.all(this, Order.ALL);
            offers = Offer.all(this);
            LoadProducts();
            employees.Add(new Employee("dataentry", "dataentry", EmployeeRole.DATA_ENTRY));
            employees.Add(new Employee("storage", "storage", EmployeeRole.STORAGE));
            employees.Add(new Employee("admin", "admin", EmployeeRole.ADMIN));
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

        public OnModelChange OnProductsChange 
        {
            set
            {
                onProductsChangeHandler = value;
            }
        }

        public bool updateOffer(Offer offer)
        {
            if (offers.Exists(o=> o.Id == offer.Id))
            {
                offer.update();
                offers[offers.FindIndex(ind => ind.Id == offer.Id)] = offer;
                if (onOffersChangeHandler != null)
                    onOffersChangeHandler();
                return true;
            }
            else   return false;
        }

        public bool deleteOffer(Offer offer)
        {
            if (offers.Exists(o => o.Id == offer.Id))
            {
                int temp = offers.IndexOf(offers.Single(o => o.Id == offer.Id));
                offers.RemoveAt(temp);
                offer.delete();
                if (onOffersChangeHandler != null)
                    onOffersChangeHandler();
                return true;
            }
            else
                return false;
        }

        public bool addOffer(Offer offer)
        {
            if (offers.Exists(o => o.Id == offer.Id))
                return false;
            else
            {
                Offer offerSaved = offer.save();
                if (offerSaved != null)
                {
                    offers.Add(offerSaved);
                    onOffersChangeHandler();
                    return true;
                }

            }

            return false;
        }

        public Product addProduct(Product product)
        {
            if (ProductList.Exists(p => p.Id == product.Id))
                return null;
            
            Product savedProduct = product.save();
            if (savedProduct != null)
            {
                ProductList.Add(savedProduct);
                if (onProductsChangeHandler != null)
                    onProductsChangeHandler();
                return savedProduct;
            }

            return null;

        }

        public bool editProduct(Product product)
        {
            if (!ProductList.Exists(p => p.Id == product.Id))
                return false;

            bool productUpdated = product.update();
            if (productUpdated)
            {
                ProductList[ProductList.FindIndex(p => p.Id == product.Id)] = product;
                if (onProductsChangeHandler != null)
                    onProductsChangeHandler();
            }

            return productUpdated;

        }

        public bool deleteProduct(Product product)
        {
            if (!ProductList.Exists(p => p.Id == product.Id))
                return false;

            bool productDeleted = product.delete();
            if (productDeleted)
            {
                ProductList.RemoveAt(ProductList.FindIndex(p => p.Id == product.Id));
                if (onProductsChangeHandler != null)
                    onProductsChangeHandler();
            }

            return productDeleted;
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
