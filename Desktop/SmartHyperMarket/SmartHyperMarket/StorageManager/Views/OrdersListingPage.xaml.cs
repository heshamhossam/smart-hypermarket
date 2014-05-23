using FirstFloor.ModernUI.Presentation;
using SmartHyperMarket.StorageManager.Controllers;
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
using SmartHyperMarket.Common.Models;
//using SmartHyperMarket.Common.StubModels;

namespace SmartHyperMarket.StorageManager.Views
{
    /// <summary>
    /// Interaction logic for OrdersListingPage.xaml
    /// </summary>
    public partial class OrdersListingPage : Page
    {
        private LinkCollection _links = new LinkCollection();
        private List<Order> _ordersWaiting;
        private OrderController _orderController = new OrderController();

        public OrdersListingPage()
        {
            InitializeComponent();
            _orderController.showOrders(this);

            tabOrders.Links = _links;
        }

        

        public void changeLinks(List<Order> orders)
        {
            _links = new LinkCollection();

            foreach (var order in orders)
            {
                _links.Add(new Link() { DisplayName = "Order " + order.Id, Source = new Uri("StorageManager/Views/OrderProductsDetailsControl.xaml#" + order.Id, UriKind.Relative) });
            }

            tabOrders.Links = _links;
        }
    }
}
