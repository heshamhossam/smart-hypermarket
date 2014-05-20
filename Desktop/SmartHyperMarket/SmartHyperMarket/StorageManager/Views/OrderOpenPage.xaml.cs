using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.Common.Models;
using SmartHyperMarket.StorageManager.Controllers;
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
        private OrderController _orderController = new OrderController();

        public OrderOpenPage()
        {
            InitializeComponent();
        }

        private void buttonOpenOrder_Click(object sender, RoutedEventArgs e)
        {
            Response response = _orderController.openOrder(
                new Input("id", id.Text),
                new Input("confirmationCode", confirmationCode.Text)
            );

            if (response.State == ResponseState.FAIL)
                MessageBox.Show(response.Errors[0].ErrorMessage);
        }
    }
}
