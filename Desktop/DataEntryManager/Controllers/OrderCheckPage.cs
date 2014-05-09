using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StorageManager.Models;
using StorageManager;

namespace DataEntryManager.Controllers
{
    class OrderCheckPage
    {
        public static OrderWindow getOrderWindow(string id, string confirmationCode)
        {
            Order order = getOrder(id);
            if (order.Confirmation_code == confirmationCode)
                return new OrderWindow(order);
            else
                return null;
        }

        private static Order getOrder(string id)
        {
            return Market.getInstance().Orders.Find((Order order) => order.Id == id);
        }
    }
}
