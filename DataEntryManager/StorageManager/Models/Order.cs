using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryManager;

namespace StorageManager.Models
{
    public class Order
    {
        const string WAITING = "WAITING";
        const string PREPARING = "PREPARING";
        const string READY = "READY";
        const string DONE = "DONE";
        const string ALL = "ALL";


        public string State { get; set; }
        public string Id { get; set; }
        public string ConfirmationCode { get; set; }
        public List<Product> Products { get; set; }

        static List<Order> LoadOrders(string state)
        {
            
        }
    }

    
}
