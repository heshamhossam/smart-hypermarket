using FirstFloor.ModernUI.Windows;
using SmartHyperMarket.Common.Models;
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

namespace SmartHyperMarket.StorageManager.Views
{
    /// <summary>
    /// Interaction logic for OrderProductsDetailsControl.xaml
    /// </summary>
    public partial class OrderProductsDetailsControl : UserControl, IContent
    {
        private Order _order = new Order(Market.getInstance());

        public OrderProductsDetailsControl(Order order)
        {
            InitializeComponent();

            _order = order;
            show(_order);
            
        }

        public OrderProductsDetailsControl()
        {
            InitializeComponent();
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            
            string id = e.Fragment;
            Market market = Market.getInstance();
            _order = market.Orders.Find(i => i.Id == id);
            show(_order);
            
        }

        public void show(Order order)
        {
            productsList.ItemsSource = order.Products;
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            
        }

        private void buttonServed_Click(object sender, RoutedEventArgs e)
        {
            _order.State = Order.READY;
            _order.update();
        }
    }
}
