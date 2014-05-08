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
        private string _id;
        private string _name;
        private string _created_at;
        private string _updated_at;
        private int? _category_id;
        private List<Product> _products;

        public string Id 
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string Created_at
        {
            get
            {
                return _created_at;
            }
            set
            {
                _created_at = value;
            }
        }

        public string Updated_at
        {
            get
            {
                return _updated_at;
            }
            set
            {
                _updated_at = value;
            }
        }

        public int? Category_id
        {
            get
            {
                return _category_id;
            }
            set
            {
                _category_id = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
            }
        }

        public static List<Category> LoadCategories(int marketId, string url)
        {
            string URL = "http://zonlinegamescom.ipage.com/smarthypermarket/public/categories/retrieve?market_id=" + marketId.ToString();
            if(url != null)
                URL = url;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string data = sr.ReadToEnd();

            List<Category> list = new List<Category>();

            if(url != null)
                list = JsonConvert.DeserializeObject<List<Category>>(data);

            return list;
        }
    }
}
