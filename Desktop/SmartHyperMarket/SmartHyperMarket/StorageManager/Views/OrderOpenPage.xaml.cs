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
    /// Interaction logic for OrderOpenPage.xaml
    /// </summary>
    public partial class OrderOpenPage : Page
    {
        public OrderOpenPage()
        {
            InitializeComponent();
        }

        private void buttonOpenOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = Market.getInstance().Orders.Find((Order order2) => order2.Id == id.Text);
            if (order != null && (order.Confirmation_code == confirmationCode.Text || true ))
            {
                OrderDetailsWindow orderPopup = new OrderDetailsWindow(order);
                orderPopup.Show();
            }
            else MessageBox.Show("Invaild Confirmation Code!");
        }
    }
}
