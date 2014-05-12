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
        private string teaser;
        private string offername;
        private float totalprice;
        private List<string> _productsid;
        private List<string> _productsquanaties;
        Market market;
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
            this.teaser = teaser;
            this.offername = offername;
            this.totalprice = totalprice;
            _productsid = new List<string>();
            _productsquanaties = new List<string>();
            GetProductfields();
            market = Market.getInstance();
        }

        public Offer save()
        {

            string URL = "http://zonlinegamescom.ipage.com/smarthypermarket/public/offers/create";

            WebClient webClient = new WebClient();

            NameValueCollection formData = new NameValueCollection();

            formData["teaser"] = teaser;

            formData["name"] = offername;
         //   MessageBox.Show(_productsid.Count.ToString());
            formData["price"] = totalprice.ToString();
            formData["market_id"] = market.Id.ToString();
          //  int index = webClient.QueryString.Count;
          //  webClient.QueryString.Add(
            for (int i = 0; i < _productsid.Count;i++ )
            {
                formData["product_id"+ i.ToString()] = _productsid[i];
                formData["product_quantity"+ i.ToString()] = _productsquanaties[i];
            }

           
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
        private void GetProductfields()
        {
            foreach(Product p in _products)
            {
                _productsid.Add(p.Id);
                _productsquanaties.Add(p.Quantity.ToString());
                
            }
        }




    }
}
