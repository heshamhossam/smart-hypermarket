using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
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

namespace DataEntryManager
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ShowProducts : Page
    {
        //  private List<Product> _productsList = new List<Product>();
        Market market;

        public ShowProducts()
        {
            
            InitializeComponent();
            market = Market.getInstance();
            productsListGrid.ItemsSource = market.Products;

        }

        private void productsListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productsListGrid.SelectedItem;
            EditProduct editProductWindow = new EditProduct(product);
            editProductWindow.Show();
        }

        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productsListGrid.SelectedItem;

            if (product != null)
                product.delete();

        }
    }
}
