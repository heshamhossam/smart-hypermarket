using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataEntryManager
{
  public  class Offer
    {

        private List<Product> _products;
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

        public Offer(List<Product> products,string teaser,string offername,float totalprice)
        {
            this._products = products;
            this._teaser = teaser;
            this._name = offername;
            this._price = totalprice;
        }

        public Offer() { }

        public Offer save(Market market)
        {

            string URL = "http://zonlinegamescom.ipage.com/smarthypermarket/public/offers/create";

            WebClient webClient = new WebClient();

            NameValueCollection formData = new NameValueCollection();

            formData["teaser"] = _teaser;
            formData["name"] = _name;
            formData["price"] = _price.ToString();
            formData["market_id"] = market.Id.ToString();

            //set both the product_ids array and the product_quantites array

           
          byte[] responseBytes = webClient.UploadValues(URL,"POST", formData);
          string responsefromserver = Encoding.UTF8.GetString(responseBytes);
          Offer p = JsonConvert.DeserializeObject<Offer>(responsefromserver);

         webClient.Dispose();
       if (responsefromserver != null)
                return this;
           else
          return null;
            //implement this ess
          
        }


    }
}
