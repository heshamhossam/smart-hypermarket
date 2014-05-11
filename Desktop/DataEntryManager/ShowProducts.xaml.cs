using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            Application.Current.MainWindow.Activate();
            market = Market.getInstance();
            market.onProductsChangeHandler = productlist_onUpdate;
            productsListGrid.ItemsSource = market.Products;
        }
        
        
        public void productlist_onUpdate()
        {
            productsListGrid.Items.Refresh();
        }

        private void buttonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productsListGrid.SelectedItem;

            if (product != null)
            {
                EditProduct editProductWindow = new EditProduct(product);
                editProductWindow.OnProductChangeHandler = productlist_onUpdate;

                editProductWindow.Show();
            }
            else
                MessageBox.Show("Please select a product first to edit");
        }

        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

            Product product = (Product)productsListGrid.SelectedItem;

            if (product != null)
            {
                if (product.delete(market))
                {
                    market.Products.Remove(product);
                    ((List<Product>)productsListGrid.ItemsSource).Remove(product);
                    productsListGrid.Items.Refresh();

                    MessageBox.Show("Product deleted successfully");
                }
                else
                    MessageBox.Show("Can't Delete product at this time...");
            }
            else
                MessageBox.Show("Please select a product first to delete");

        }

    }
}
