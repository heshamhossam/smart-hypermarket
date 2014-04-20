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
        List<Category> p;
        string id;
        public AddProduct()
        {
            InitializeComponent();

            #region Bardetecting Example
            OnBarcodeDetectedDelegate testD = testDelegateFunction; //Testing variable for OnBarcodeDetectedDelegate
            BarcodeReading.BarcodeReader bcr = new BarcodeReading.BarcodeReader(ref barcode,ref player); //Testing variable for BarcodeReader class ( see constructor documentation )
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
            try
            {

                string URL = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/create";

                WebClient webClient = new WebClient();

                NameValueCollection formData = new NameValueCollection();

                formData["name"] = name.Text;

                formData["barcode"] = barcode.Text;

                formData["price"] = price.Text;

                formData["category_id"] = id;

                byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);

                string responsefromserver = Encoding.UTF8.GetString(responseBytes);

                webClient.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //  Console.WriteLine(responsefromserver);

          
        }
        private void LoadComboxList()
        {
            string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/categories/retrieve";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader sr = new StreamReader(response.GetResponseStream());

            string data = sr.ReadToEnd();

            p = JsonConvert.DeserializeObject<List<Category>>(data);


            //add in the box
            foreach (Category cat in p)
            {
                category.Items.Add(cat.CategoryName);
            }
        }

       
        private void category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sel = category.SelectedItem.ToString();
            Category catselected = p.Find(i => i.CategoryName == sel);
            //   MessageBox.Show(catselected.categoryID + "   " + catselected.categoryName);
            id = catselected.CategoryID;

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
