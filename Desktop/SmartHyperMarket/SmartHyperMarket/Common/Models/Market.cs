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
    public delegate void OnProductsChange();

    public class Market : IMarket
    {
        public OnProductsChange onProductsChangeHandler;
        private static Market MyMarket;
        private List<Product> ProductList = new List<Product>();
        private List<Category> CategoryList = new List<Category>();
        private List<Order> orders = new List<Order>();
        private List<Employee> employees = new List<Employee>();

        private Market()
        {
            CategoryList = Category.all(this);
            orders = Order.all(this, Order.ALL);
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

        public int Id
        {
            get { return 1; }

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
