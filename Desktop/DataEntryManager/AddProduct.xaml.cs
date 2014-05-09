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

using Controllers = DataEntryManager.Controllers;

namespace DataEntryManager
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        Market market;
        
        /// <summary>
        /// instaniate a market, load it's categoreis on category combolist and begin detection of barcode process
        /// </summary>
        public AddProduct()
        {
            InitializeComponent();
            market = Market.getInstance();

            #region Bardetecting Example
            //OnBarcodeDetectedDelegate testD = testDelegateFunction; //Testing variable for OnBarcodeDetectedDelegate
            BarcodeReading.BarcodeReader bcr = new BarcodeReading.BarcodeReader(ref barcode, ref player); //Testing variable for BarcodeReader class ( see constructor documentation )
            //bcr.onBarcodeDetected += testD; //Adding the delegate function to onBarcodeDetected variable at bcr to fire it after detecting barcode emplicitily
            //If camera opened successfully read barcode and fire onBarcodeDetected delegate
            //if (bcr.openCamera() == true)
            bcr.readBarcodes();
            #endregion
            
            Controllers.AddProduct.LoadComboxList(ref market, ref category);
        }

        /// <summary>
        /// Send the product data to be added to database and show messaging depending on the result of the process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = Controllers.AddProduct.Add(ref market, ref name, ref barcode, ref price, ref category, ref textboxDescription, ref textboxWeight);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Product Added Successfully");
                    Controllers.AddProduct.clearAddProductForm(ref name, ref barcode, ref category, ref price);
                    break;
                case 1:
                    MessageBox.Show("Problem Happen While Adding the Product");
                    break;
                case 2:
                    MessageBox.Show("You Must Fill All Fields");
                    break;
                default:
                    MessageBox.Show("Unknown error");
                    break;
            }
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
