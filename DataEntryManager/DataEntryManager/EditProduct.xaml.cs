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

namespace DataEntryManager
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private Product _product;
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
            _product.Name = name.Text;
            _product.Barcode = barcode.Text;
            //_product.Market_id = "1";
            _product.Price = float.Parse(price.Text);

            bool updated = _product.update();

            if (updated)
            {
                MessageBox.Show("Product edited successfully.", "Confirmation message", MessageBoxButton.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Happened while Editing your product, please try again later!!.", "Confirmation message", MessageBoxButton.OK);
            }

            
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
