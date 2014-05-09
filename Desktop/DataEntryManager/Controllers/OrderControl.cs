using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageManager.Models;
using System.Windows.Controls;

namespace DataEntryManager.Controllers
{
    class OrderControl
    {
        public static void showOrder(string id, ref DataGrid productsList) {
            Market market = Market.getInstance();
            Order order = market.Orders.Find(i => i.Id == id);
            if(order != null)
                show(order, ref productsList);
        }

        private static void show(Order order, ref DataGrid productsList)
        {
            productsList.ItemsSource = order.Products;
        }

        public static void changeToServed(ref Order order) {
            order.State = Order.READY;
            order.update(null);
        }
    }
}
