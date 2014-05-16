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
using System.Windows.Shapes;

namespace SmartHyperMarket.StorageManager.Views
{
    /// <summary>
    /// Interaction logic for OrderDetailsWindow.xaml
    /// </summary>
    public partial class OrderDetailsWindow : Window
    {
        public OrderDetailsWindow(Order order)
        {
            InitializeComponent();
            textBlockId.Text = order.Id;
            textBlockCode.Text = order.Confirmation_code;
            textBlockState.Text = order.State;
            textBlockTotalcost.Text = order.TotalCost.ToString();
            //dataGridProductsList.ItemsSource = order.Products;
            OrderProductsDetailsControl orderProductsDetailsControl = new OrderProductsDetailsControl(order);
            stackPanelOrderProducts.Children.Add(orderProductsDetailsControl);
        }
    }
}
