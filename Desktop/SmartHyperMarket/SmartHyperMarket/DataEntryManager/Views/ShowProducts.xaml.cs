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
using SmartHyperMarket.Common.Models;
using SmartHyperMarket.DataEntryManager.Controllers;
using SmartHyperMarket.Common.Controllers;

namespace SmartHyperMarket.DataEntryManager.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ShowProducts : Page
    {
        ProductController _productController = new ProductController();
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
                editProductWindow.Show();
            }
            else
                MessageBox.Show("Please select a product first to edit");
        }

        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            
            Product product = (Product)productsListGrid.SelectedItem;
            _productController.Product = product;
            Response response = _productController.deleteProduct(product);

            if (response.State == ResponseState.SUCCESS)
                MessageBox.Show("Product deleted successfully");
            else
                MessageBox.Show("Can't Delete product at this time...");


        }

    }
}
