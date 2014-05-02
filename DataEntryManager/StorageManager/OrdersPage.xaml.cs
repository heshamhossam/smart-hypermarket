using DataEntryManager;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using StorageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StorageManager
{
    /// <summary>
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private LinkCollection links = new LinkCollection();
        private List<Order> _ordersWaiting;

        public OrdersPage()
        {
            InitializeComponent();
            tabOrders.Links = links;

            //load the _ordersWaiting
            _ordersWaiting = Market.getInstance().Orders.FindAll((Order order) => order.State == Order.WAITING);
            changeLinks(_ordersWaiting);


            //start threading to check any new orders
            startOrdersCheckingThread();

        }

        private void changeLinks(List<Order> orders)
        {
            links = new LinkCollection();
            
            foreach(var order in orders)
            {
                links.Add(new Link() { DisplayName = order.Id, Source = new Uri("OrderControl.xaml#" + order.Id, UriKind.Relative) });
            }
            tabOrders.Links = links;
        }

        private void startOrdersCheckingThread()
        {

        }
    }
}
