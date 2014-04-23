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
        int LNum, NNum;

        public ShowProducts()
        {

            InitializeComponent();
            Application.Current.MainWindow.Activate();
            market = Market.getInstance();
            productsListGrid.ItemsSource = market.Products;


        }

        private void productsListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productsListGrid.SelectedItem;

            if (product != null)
            {
                EditProduct editProductWindow = new EditProduct(product);
                editProductWindow.Show();
            }
            else
                MessageBox.Show("Please select a product first to edit");
        }

        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

            Product product = (Product)productsListGrid.SelectedItem;

            if (product != null)
                product.delete();
            else
                MessageBox.Show("Please select a product first to delete");

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // productsListGrid.Items.Refresh();
            LNum = market.Products.Count;
            market = Market.getInstance();
            NNum = market.Products.Count;
            if (NNum > LNum)
            {
                LNum = NNum - LNum;
                MessageBox.Show(string.Format("There are {0} New Products", LNum));
            }
            else
            {
                MessageBox.Show("There Is Not Any New Products");
            }

            productsListGrid.ItemsSource = market.Products;
        }
    }
}
