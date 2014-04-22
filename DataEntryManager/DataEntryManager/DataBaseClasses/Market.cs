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
        private int marketid;
        private List<Product> ProductList;
        private List<Category> CategoryList;
        private Market()
        {

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
            else
            {
                MyMarket.ProductList = new List<Product>();
                MyMarket.CategoryList = new List<Category>();

                MyMarket.LoadCategories();
                MyMarket.LoadProducts();
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

        public void LoadCategories()
        {
            string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/categories/retrieve?market_id=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string data = sr.ReadToEnd();

            List<Category> list = JsonConvert.DeserializeObject<List<Category>>(data);
            CategoryList = list;
            //add in the box
        }
        private void LoadProducts()
        {
            string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/categories/retrieve?market_id=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            string data = streamReader.ReadToEnd();

            List<Category> categoriesList = JsonConvert.DeserializeObject<List<Category>>(data);

            for (int i = 0; i < categoriesList.Count; i++)
            {
                foreach (var product in categoriesList[i].Products)
                {
                    ProductList.Add(product);
                }
            }

        }
    }
}