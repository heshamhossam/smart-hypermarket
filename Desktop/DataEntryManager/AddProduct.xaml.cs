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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BarcodeReading;
using WpfCap;
using ZXing;

using BarcodeReader = ZXing.Presentation.BarcodeReader;
using BarcodeWriter = ZXing.Presentation.BarcodeWriter;
using BarcodeWriterGeometry = ZXing.Presentation.BarcodeWriterGeometry;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace DataEntryManager
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {

        string id;
        Market market;
      
        public AddProduct()
        {
            InitializeComponent();
            market = Market.getInstance();

            #region Bardetecting Example
            OnBarcodeDetectedDelegate testD = testDelegateFunction; //Testing variable for OnBarcodeDetectedDelegate
            BarcodeReading.BarcodeReader bcr = new BarcodeReading.BarcodeReader(ref barcode, ref player); //Testing variable for BarcodeReader class ( see constructor documentation )
            bcr.onBarcodeDetected += testD; //Adding the delegate function to onBarcodeDetected variable at bcr to fire it after detecting barcode emplicitily
            //If camera opened successfully read barcode and fire onBarcodeDetected delegate
            //if (bcr.openCamera() == true)
            bcr.readBarcodes();
            #endregion
            
            LoadComboxList();
        }
        public void testDelegateFunction()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckFields())
            {
                Product p = new Product(name.Text, barcode.Text, float.Parse(price.Text), id, textboxWeight.Text, textboxDescription.Text);
                Product product = p.save(market, null);

                if (p != null)
                {
                    market.Products.Add(product);
                    market.onProductsChangeHandler();

                    MessageBox.Show("Product Added Successfully");

                }
                else
                {
                    MessageBox.Show("Problem Happen While Adding the Product");
                }
                name.Text = "";
                barcode.Text = "";
                category.SelectedIndex = -1;
                price.Text = "";

                //  Console.WriteLine(responsefromserver);
            }
            else
            {
                MessageBox.Show("You Mush Fill All Fields");
            }
           
        }

      
        private void LoadComboxList()
        {
            
            //add in the box
            foreach (Category cat in market.Categories)
            {
                category.Items.Add(cat.Name);
            }
        }

      private  bool CheckFields()
        {
            if (name.Text == "" || barcode.Text == "" || price.Text == "" || category.SelectedItem == null || textboxDescription.Text=="" || textboxWeight.Text == "" )
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private void category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (category.SelectedIndex == -1)
            { }
            else
            {
                string sel = category.SelectedItem.ToString();
                Category catselected = market.Categories.Find(i => i.Name == sel);
                //   MessageBox.Show(catselected.CategoryID + "   " + catselected.CategoryName);
                id = catselected.Id;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

    //Related to scaling player that is declared in XML file
    public class ScaleConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float v = (float)values[0];
            double m = (double)values[1];
            return v * m / 50;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
