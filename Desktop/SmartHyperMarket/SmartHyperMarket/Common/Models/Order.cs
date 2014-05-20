using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHyperMarket;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace SmartHyperMarket.Common.Models
{
    public class Order : Model<Order>, IOrder
    {
        private string _Id;
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        
        private string _State;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        private string _Market_id;
        public string Market_id
        {
            get { return _Market_id; }
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
        public float TotalCost
        {
            get
            {
                if (_totalCost > 0)
                    return _totalCost;

                foreach (Product product in _Products)
                {
                    _totalCost += product.Price;
                }

                return _totalCost;
            }
        }

        protected static string WebserviceURLFull
        {
            get { return Model<Order>.webServiceParent + "/orders"; }

        }
        
        public const string WAITING = "WAITING";
        public const string PREPARING = "PREPARING";
        public const string READY = "READY";
        public const string DONE = "DONE";
        public const string ALL = "ALL";

        public Order(Market market)
        {
            _market = market;
        }

        public static List<Order> all(Market market, string filter)
        {
            string url = WebserviceURLFull + "/retrieve?market_id=" + market.Id + "&filter=" + filter;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            List<Order> list = new List<Order>();

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string data = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Order>>(data);
            }
            catch
            {
                return null;
            }

            return list;
        }


        public override bool update()
        {
            string url = WebserviceURLFull + "/edit?order_id=" + this._Id + "&state=" + this._State;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
                return false;
            }
            return true;
        }

        
        public bool isAllowableState(string state)
        {
            switch (state)
            {
                case Order.READY:
                case Order.PREPARING:
                case Order.DONE:
                case Order.WAITING:
                    return true;
                    break;

                default:
                    return false;
                    break;
            }
        }

        public override Order save()
        {
            return default(Order);
        }

        public override bool delete()
        {
            return false;
        }
    }

    
}
