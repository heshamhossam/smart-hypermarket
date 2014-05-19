using FirstFloor.ModernUI.Presentation;
using SmartHyperMarket.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace SmartHyperMarket.StorageManager.Views
{
    /// <summary>
    /// Interaction logic for OrdersListingPage.xaml
    /// </summary>
    public partial class OrdersListingPage : Page
    {
        private LinkCollection _links = new LinkCollection();
        private List<Order> _ordersWaiting;

        public OrdersListingPage()
        {
            InitializeComponent();

            tabOrders.Links = _links;

            //load the _ordersWaiting
            _ordersWaiting = Market.getInstance().Orders.FindAll((Order order) => order.State == Order.WAITING);
            changeLinks(_ordersWaiting);


            //start threading to check any new orders
            startOrdersCheckingThread();
        }

        void Refresh()
        {
            while(true)
            {
                int timer = 3000;
                Thread.Sleep(timer);
                Market.getInstance().refreshOrders();
                _ordersWaiting = Market.getInstance().Orders.FindAll((Order order) => order.State == Order.WAITING);
                Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() => { changeLinks(_ordersWaiting); }));

            }
        }

        private void changeLinks(List<Order> orders)
        {
            _links = new LinkCollection();

            foreach (var order in orders)
            {
                _links.Add(new Link() { DisplayName = "Order " + order.Id, Source = new Uri("StorageManager/Views/OrderProductsDetailsControl.xaml#" + order.Id, UriKind.Relative) });
            }
            tabOrders.Links = _links;
        }

        private void startOrdersCheckingThread()
        {
            Thread T = new Thread(Refresh);
            T.Start();
        }
    }
}
