using DataEntryManager;
using FirstFloor.ModernUI.Windows;
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
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl, IContent
    {
        private Order order = new Order();
        public OrderControl()
        {
            InitializeComponent();
            
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            string id = e.Fragment;
            Market market = Market.getInstance();
            //search market orders for the required order with the prev id
            List<Order> ordersList = Order.LoadOrders(market, id);
            order = ordersList.Find(i => i.Id == id);
            show(order);
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
            order.State = Order.WAITING;
            //order.update();
        }
    }
}
