using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataEntryManager
{
    public class Offer
    {
        private List<Product> _products = new List<Product>();
        private string _teaser;
        private string _name;
        private float _price;

        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public string Teaser {
            get
            {
                return _teaser;
            }
            set
            {
                _teaser = value;
            }
        }

        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public float Price {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public Offer(List<Product> products, string teaser, string offername, float totalprice)
        {
            this._products = products;
            this._teaser = teaser;
            this._name = offername;
            this._price = totalprice;
        }

        public Offer() { }

        public Offer save(Market market)
        {

            string URL = "http://zonlinegamescom.ipage.com/smarthypermarket/public/offers/create?";

            //WebClient webClient = new WebClient();

            //NameValueCollection formData = new NameValueCollection();

            //formData["teaser"] = _teaser;
            //formData["name"] = _name;
            //formData["price"] = _price.ToString();
            //formData["market_id"] = market.Id.ToString();
            
            ////set both the product_ids array and the product_quantites array
            ////List<string> product_ids_values = new List<string>();
            //for (int i = 0; i < _products.Count; i++)
            //{
            //    formData["product_id"+i.ToString()] = _products[i].Id;
            //    formData["product_quantity" + i.ToString()] = _products[i].Quantity.ToString();
            //}
            ////List<string> product_quantites_values = new List<string>();
            ////foreach (Product product in _products)
            ////{
            ////    product_quantites_values.Add(product.Quantity.ToString());
            ////}
            ////webClient.AddArray("product_ids", product_ids_values);
            ////webClient.AddArray("product_quantites", product_quantites_values);
            ////================================================================

            //byte[] responseBytes = webClient.UploadValues(URL,"GET", formData);
            //string responsefromserver = Encoding.UTF8.GetString(responseBytes);
            ////Offer p = JsonConvert.DeserializeObject<Offer>(responsefromserver);

            //webClient.Dispose();
            //if (responsefromserver != null)
            //    return this;
            //else
            //{
            //    MessageBox.Show("null response");
            //    return null;
            //}

            URL += "teaser=" + _teaser + "&name=" + _name + "&price=" + _price.ToString() + "&market_id=" + market.Id;

            for (int i = 0; i < _products.Count; i++)
            {
                URL += "&product_id" + i.ToString() + "=" + _products[i].Id;
                URL += "&product_quantity" + i.ToString() + "=" + _products[i].Quantity.ToString();
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string data = sr.ReadToEnd();

            Offer offer = JsonConvert.DeserializeObject<Offer>(data);

            return offer;
        }
    }
}
