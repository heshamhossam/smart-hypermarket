using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryManager;

namespace StorageManager.Models
{
    public class Order : IOrder
    {
        public const string WAITING = "WAITING";
        public const string PREPARING = "PREPARING";
        public const string READY = "READY";
        public const string DONE = "DONE";
        public const string ALL = "ALL";


        //static List<Order> LoadOrders(Market market, string filter)
        //{
            
        //}
    }

    
}
