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
using StorageManager.Models;

namespace StorageManager
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow(Order order)
        {
            InitializeComponent();
            id.Text = order.Id;
            code.Text = order.Confirmation_code;
            state.Text = order.State;
            totalcost.Text = order.TotalCost.ToString();
            productsList.ItemsSource = order.Products;
        
        }
    }
}
