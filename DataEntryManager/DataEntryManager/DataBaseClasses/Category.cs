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
    public class Category : ICategory
    {
        private string categoryID;
        private string categoryName;
        private List<Product> products;

        public string CategoryID
        {
            get
            {
                return categoryID;
            }
            set
            {
                categoryID = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }

        public static List<Category> LoadCategories(int marketId)
        {
            string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/categories/retrieve?market_id=" + marketId;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string data = sr.ReadToEnd();

            List<Category> list = JsonConvert.DeserializeObject<List<Category>>(data);

            return list;
        }
    }
}
