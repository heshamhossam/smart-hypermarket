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

namespace SmartHyperMarket.Common.Models
{
    public class Offer : Model<Offer>
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
        protected static string WebserviceURLFull
        {
            get { return Model<Offer>.webServiceParent + "/offers";  }
        }
        
        public Offer(List<Product> products, string teaser, string offername, float totalprice, Market market)
        {
            this._products = products;
            this._teaser = teaser;
            this._name = offername;
            this._price = totalprice;
            this._market = market;
        }

        public Offer(Market market) 
        {
            this._market = market;
        }

        public Offer()
        {

        }
        

        public override bool update()
        {
            return false;
        }

        public override bool delete()
        {
            return false;
        }


        public override Offer save()
        {
            string URL = WebserviceURLFull + "/create?";

            URL += "teaser=" + _teaser + "&name=" + _name + "&price=" + _price.ToString() + "&market_id=" + _market.Id;

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

        public static List<Offer> all(Market market)
        {
            List<Offer> offers = new List<Offer>();
                
            //implemenet de ya shafik

            return offers;
        }
    }
}
