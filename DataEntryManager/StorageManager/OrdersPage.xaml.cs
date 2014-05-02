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

        public OrdersPage()
        {
            InitializeComponent();
            var market = Market.getInstance();
            
            tabOrders.Links = links;
        }

        private void changeLinks(List<Order> orders)
        {
            LinkCollection newLinks = new LinkCollection();
            foreach(var order in orders)
            {
                newLinks.Add(new Link() { DisplayName = order.Id, Source = new Uri("OrderControl.xaml#" + order.Id, UriKind.Relative) });
            }
            links = newLinks;
        }

    }
}
