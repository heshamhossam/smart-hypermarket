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

namespace SmartHyperMarket.Common.StubModels
{
    public class Offer : Model<Offer>
    {
        public class Offers
    {
        public List<Offer> offers { get; set; }
    }
        private string _name;
        private string _price;
        private string _id;
        private string _teaser;
        private string _market_id;
        private string _created_at;
        private string _updated_at;
        private List<Product> _products = new List<Product>();


        public List<Product> Products
        {
            set { _products = value; }
            get { return _products; }

        }
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public string Price
        {
            set { _price = value; }
            get { return _price; }
        }
        public string Id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string Teaser
        {
            set { _teaser = value; }
            get { return _teaser; }
        }
        public string Market_id
        {
            set { _market_id = value; }
            get { return _market_id; }
        }
        public string Created_at
        {
            set { _created_at = value; }
            get { return _created_at; }
        }
        public string Updated_at
        {
            set { _updated_at = value; }
            get { return _updated_at; }
        }

        private static string WebserviceURLFull
        {
            get { return Model<Offer>.webServiceParent + "/offers";  }
        }
        
        public Offer(List<Product> products, string teaser, string offername, string totalprice, Market market)
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
            string tempt = this.Teaser.Replace(" ", "%20");
            string tempn = this.Name.Replace(" ", "%20");
            string url = WebserviceURLFull + "/edit?offer_id="+this.Id+"&name="+tempn+"&teaser="+tempt+"&price="+this.Price;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                MessageBox.Show("Server connection error.");
            }
            return true;
        }

        public override bool delete()
        {
            string url = WebserviceURLFull + "/delete?offer_id=" + this.Id;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                MessageBox.Show("Server connection error.");
            }
            return true;
        }


        public override Offer save()
        {
            string URL = WebserviceURLFull + "/create?";

            URL = URL + "&teaser=" + Teaser + "&name=" + Name + "&price=" + Price.ToString() + "&market_id=" + _market.Id;

            for (int i = 0; i < _products.Count; i++)
            {
                URL += "&product_id" + i.ToString() + "=" + _products[i].Id;
                URL += "&product_quantity" + i.ToString() + "=" + _products[i].Quantity.ToString();
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            Offer offer = new Offer();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string data = sr.ReadToEnd();
                offer = JsonConvert.DeserializeObject<Offer>(data);
            }
            catch
            {
                MessageBox.Show("Server connection error.");
            }
            return offer;
        }

        public static List<Offer> all(Market market)
        {
            string url = WebserviceURLFull + "/retrieve?market_id=" + market.Id.ToString();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            Offers g = new Offers();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string data = sr.ReadToEnd();
                g = JsonConvert.DeserializeObject<Offers>(data);
            }
            catch
            {
                MessageBox.Show("Server connection error.");
            }
            return g.offers;
        }
    }
}
