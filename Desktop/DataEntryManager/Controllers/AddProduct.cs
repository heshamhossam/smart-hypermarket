using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace DataEntryManager.Controllers
{
    class AddProduct
    {
        /// <summary>
        /// Load categories on a combobox
        /// </summary>
        /// <param name="market"></param>
        /// <param name="category"></param>
        public static void LoadComboxList(ref Market market, ref ComboBox category)
        {
            //add in the box
            foreach (Category cat in market.Categories)
                category.Items.Add(cat.Name);
        }

        /// <summary>
        /// Add Product to database
        /// </summary>
        /// <param name="market"></param>
        /// <param name="name"></param>
        /// <param name="barcode"></param>
        /// <param name="price"></param>
        /// <param name="category"></param>
        /// <param name="textboxDescription"></param>
        /// <param name="textboxWeight"></param>
        /// <returns>0 if success and 1 or 2 if failed</returns>
        public static Response Add(ref Market market, ref TextBox name, ref TextBox barcode, ref TextBox price, ref ComboBox category, ref TextBox textboxDescription, ref TextBox textboxWeight)
        {
            if (CheckFields(ref name, ref barcode, ref price, ref category, ref textboxDescription, ref textboxWeight))
            {
                string categorySelectedID = CategorySelectedID(ref market, ref category);

                Product product = new Product(name.Text, barcode.Text, float.Parse(price.Text), categorySelectedID, textboxWeight.Text, textboxDescription.Text);
                product = product.save(market, null);

                if (product != null)
                {
                    market.Products.Add(product);
                    market.onProductsChangeHandler();
                    return Response.Added;
                }
                else
                    return Response.Add_Failed;
            }
            else
                return Response.Empty_Fields;
        }

        /// <summary>
        /// check fields of product if some are empty or not
        /// </summary>
        /// <param name="name"></param>
        /// <param name="barcode"></param>
        /// <param name="price"></param>
        /// <param name="category"></param>
        /// <param name="textboxDescription"></param>
        /// <param name="textboxWeight"></param>
        /// <returns>true if all fields filled and false if some not</returns>
        private static bool CheckFields(ref TextBox name, ref TextBox barcode, ref TextBox price, ref ComboBox category, ref TextBox textboxDescription, ref TextBox textboxWeight)
        {
            if (name.Text == "" || barcode.Text == "" || price.Text == "" || category.SelectedItem == null || textboxDescription.Text == "" || textboxWeight.Text == "")
                return false;
            else
                return true;
        }

        /// <summary>
        /// check for category list
        /// </summary>
        /// <param name="market"></param>
        /// <param name="category"></param>
        /// <returns>string of id currently selected</returns>
        private static string CategorySelectedID(ref Market market, ref ComboBox category) {
            if (category.SelectedIndex != -1)
            {
                string sel = category.SelectedItem.ToString();
                Category catselected = market.Categories.Find(i => i.Name == sel);
                return catselected.Id;
            }
            else
                return null;
        }

        /// <summary>
        /// clear add product form
        /// </summary>
        /// <param name="name"></param>
        /// <param name="barcode"></param>
        /// <param name="category"></param>
        /// <param name="price"></param>
        public static void clearAddProductForm(ref TextBox name, ref TextBox barcode, ref ComboBox category, ref TextBox price)
        {
            name.Text = "";
            barcode.Text = "";
            category.SelectedIndex = -1;
            price.Text = "";
        }
    }
}
