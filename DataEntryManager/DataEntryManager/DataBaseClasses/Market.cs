using Newtonsoft.Json;
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
            LoadCategories();
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
