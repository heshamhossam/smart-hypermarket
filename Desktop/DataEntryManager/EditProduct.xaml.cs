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

using Controllers = DataEntryManager.Controllers;

namespace DataEntryManager
{
    public delegate void OnProductUpdate();

    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public OnProductUpdate OnProductChangeHandler = null;

        /// <summary>
        /// Constructor of edit product page
        /// </summary>
        /// <param name="product">the product to edit</param>
        public EditProduct(Product product)
        {
            InitializeComponent();

            //show the product in the text boxes, ...
            Controllers.EditProduct.showProduct(ref product, ref name, ref barcode, ref price);
        }

        /// <summary>
        /// On pressing edit button after choosing a product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProductEdit_Click(object sender, RoutedEventArgs e)
        {
            bool updated = Controllers.EditProduct.editProduct(ref name, ref barcode, ref price);

            if (updated)
            {
                MessageBox.Show("Product edited successfully.", "Confirmation message", MessageBoxButton.OK);
                
                OnProductChangeHandler();

                this.Close();
            }
            else
            {
                MessageBox.Show("Error Happened while Editing your product, please try again later!!.", "Confirmation message", MessageBoxButton.OK);
            }
        }
    }
}
