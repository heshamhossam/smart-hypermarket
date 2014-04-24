﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager
{
    public class Market : IMarket
    {
        private static Market MyMarket;
        private List<Product> ProductList = new List<Product>();
        private List<Category> CategoryList = new List<Category>();
        private Market()
        {
            CategoryList = Category.LoadCategories(1);
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
                    product.Category_id = Categories[i].CategoryID;
                    ProductList.Add(product);
                }
            }

        }
    }
}
