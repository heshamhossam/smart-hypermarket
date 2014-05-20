using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartHyperMarket.Common.Models
{
    public class Category : Model<Category>, ICategory
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
        protected static string WebserviceURLFull
        {
            get { return Model<Offer>.webServiceParent + "/categories"; }
        }

        public static List<Category> all(Market market)
        {
            string url = WebserviceURLFull + "/retrieve?market_id=" + market.Id.ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            List<Category> list = new List<Category>();

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string data = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Category>>(data);
            }
            catch
            {
                MessageBox.Show("Server connection error.");
            }

            return list;
        }


        public override Category save()
        {
            return default(Category);
        }

        public override bool update()
        {
            return false;
        }

        public override bool delete()
        {
            return false;
        }
    }
}
