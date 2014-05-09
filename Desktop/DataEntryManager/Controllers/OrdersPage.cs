using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StorageManager;
using System.Threading;
using System.Windows.Threading;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using StorageManager.Models;
using System.Windows.Navigation;

namespace DataEntryManager.Controllers
{
    class OrdersPage
    {
        public delegate void MyDelegate(List<Order> orders, ref LinkCollection links, ref ModernTab tabOrders);

        public static void Refresh(ref List<Order> ordersWaiting)
        {
            while (true)
            {
                MyDelegate del = changeLinks;
                int timer = 3000;
                Thread.Sleep(timer);
                Market.getInstance().refreshOrders();
                ordersWaiting = Market.getInstance().Orders.FindAll((Order order) => order.State == Order.WAITING);
            }
        }

        public static void changeLinks(List<Order> orders, ref LinkCollection links, ref ModernTab tabOrders)
        {
            links = new LinkCollection();

            foreach (var order in orders)
            {
                links.Add(new Link() { DisplayName = order.Id, Source = new Uri("OrderControl.xaml#" + order.Id, UriKind.Relative) });
            }
            tabOrders.Links = links;
        }
    }
}
