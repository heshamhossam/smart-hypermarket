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
    /// Interaction logic for OrderCheckPage.xaml
    /// </summary>
    public partial class OrderCheckPage : Page
    {
        public OrderCheckPage()
        {
            InitializeComponent();
        }

        private void buttonOpenOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = Market.getInstance().Orders.Find((Order order2) => order2.Id == id.Text);
            
            if (order != null)
            {
                if(order.State != Order.READY)
                    notification.Content = "Order not ready yet or already delivered";
                else if(confirmationCode.Text != order.Confirmation_code)
                    notification.Content = "Wrong confirmtation code";
                else
                {
                    created_at.Content = order.Created_at;
                    updated_at.Content = order.Updated_at;
                    market_id.Content = order.Market_id;
                    user_id.Content = order.User_id;
                    created_at_label.Content = "Created at : ";
                    updated_at_label.Content = "Created at : ";
                    market_label.Content = "Makret : ";
                    user_label.Content = "User : ";
                }
            }
            else
                notification.Content = "No order with this id";
        }

        private void buttonDeliverOrder_Click(object sender, RoutedEventArgs e)
        {
            Market market = Market.getInstance();
            Order order = market.Orders.Find(i => i.Id == id.Text);
            if (order != null)
            {
                if (confirmationCode.Text != order.Confirmation_code)
                    notification.Content = "Wrong confirmtation code";
                else
                {
                    order.State = Order.DONE;
                    order.update();
                    notification.Content = "Order Delivered";
                }

            }
            else
                notification.Content = "No order with this id";
        }
    }
}
