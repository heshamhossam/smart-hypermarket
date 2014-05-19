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
using SmartHyperMarket.Common.Models;
using SmartHyperMarket.DataEntryManager.Controllers;
using SmartHyperMarket.Common.Controllers;

namespace SmartHyperMarket.DataEntryManager.Views
{
    public delegate void OnProductUpdate();

    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private Product _product;
        private ProductController _productController = new ProductController();
        public OnProductUpdate OnProductChangeHandler = null;

        /// <summary>
        /// Constructor of edit product page
        /// </summary>
        /// <param name="product">the product to edit</param>
        public EditProduct(Product product)
        {
            InitializeComponent();

            _product = product;

            //show the product in the text boxes, ...
            showProduct(_product);

        }

        private void buttonProductEdit_Click(object sender, RoutedEventArgs e)
        {
            Response response = _productController.editProduct(_product,
                new Input("name", name.Text),
                new Input("barcode", barcode.Text),
                new Input("price", price.Text)
            );

            if (response.State == ResponseState.SUCCESS)
            {
                MessageBox.Show("Product edited successfully.", "Confirmation message", MessageBoxButton.OK);
                this.Close();
            }
            else
                MessageBox.Show("Error Happened while Editing your product, please try again later!!.", "Confirmation message", MessageBoxButton.OK);

            
        }

        /// <summary>
        /// Show Product member fields in the textboxes and other input fields
        /// </summary>
        /// <param name="product">product to show</param>
        private void showProduct(Product product)
        {
            _product.Id = product.Id;
            name.Text = product.Name;
            barcode.Text = product.Barcode;
            //market_id.Text = product.Market_id;
            price.Text = product.Price.ToString();
        }
    }
}
