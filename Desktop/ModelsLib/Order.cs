using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryManager;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace StorageManager.Models
{
    public class Order : IOrder
    {
        private string _Id;
        public string Id
        {
            get{return _Id;}
            set{_Id = value;}
        }
        private string _State;
        public string State
        { 
            get {return _State;}
            set { _State = value; }
        }

        private string _Market_id;

        public string Market_id
        {
            get {  return _Market_id; }
            set { _Market_id = value; }

        }

        private string _User_id;
        public string User_id
        {
            get { return _User_id; }
            set { _User_id = value; }        
        }

        private string _Confirmation_code;
        public string Confirmation_code
        {
            get { return _Confirmation_code; }
            set { _Confirmation_code = value; }
       }
        private string _Created_at;
        public string Created_at
        {
            get { return _Created_at; }
            set { _Created_at = value; }
        }

        private string _Updated_at;
        public string Updated_at
        {
            get { return _Updated_at; }
            set { _Updated_at = value; }
        }


        private List<Product> _Products;
        public List<Product> Products 
        {
            get { return _Products; }
            set { _Products = value; }
        }

        private float _totalCost;
        public float TotalCost {
            get
            {
                if (_totalCost > 0)
                    return _totalCost;

                foreach(Product product in _Products)
                {
                    _totalCost += product.Price;
                }

                return _totalCost;
            }
        }


        public const string WAITING = "WAITING";
        public const string PREPARING = "PREPARING";
        public const string READY = "READY";
        public const string DONE = "DONE";
        public const string ALL = "ALL";


        public static List<Order> LoadOrders (Market market, string filter)
        {
            string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/orders/retrieve?market_id=" + market.Id + "&filter=" + filter;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string data = sr.ReadToEnd();

            List<Order> list = JsonConvert.DeserializeObject<List<Order>>(data);
            
            return list;
        }

        public void update ()
        {

            string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/orders/edit?order_id=" + this._Id +"&state="+this._State;

            System.Windows.MessageBox.Show(url + this._Confirmation_code);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }

    }

    
}
