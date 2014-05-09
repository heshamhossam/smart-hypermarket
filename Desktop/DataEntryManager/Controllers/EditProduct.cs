using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DataEntryManager.Controllers
{
    class EditProduct
    {
        /// <summary>
        /// Show Product member fields in the textboxes and other input fields
        /// </summary>
        /// <param name="product"></param>
        /// <param name="_product"></param>
        /// <param name="name"></param>
        /// <param name="barcode"></param>
        /// <param name="price"></param>
        public static void showProduct(ref Product product, ref TextBox name, ref TextBox barcode, ref TextBox price)
        {
            name.Text = product.Name;
            barcode.Text = product.Barcode;
            //market_id.Text = product.Market_id;
            price.Text = product.Price.ToString();
        }

        /// <summary>
        /// edit the current instance product in database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="barcode"></param>
        /// <param name="price"></param>
        /// <returns>true or false depending on weither product updated or not</returns>
        public static bool editProduct(ref TextBox name, ref TextBox barcode, ref TextBox price)
        {
            Product product = new Product();
            product.Name = name.Text;
            product.Barcode = barcode.Text;
            //_product.Market_id = "1";
            product.Price = float.Parse(price.Text);

            return product.update(null);
        }
    }
}
