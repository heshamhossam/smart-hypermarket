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
using SmartHyperMarket.DataEntryManager.BarcodeReading;
using WpfCap;
using ZXing;

using BarcodeReader = ZXing.Presentation.BarcodeReader;
using BarcodeWriter = ZXing.Presentation.BarcodeWriter;
using BarcodeWriterGeometry = ZXing.Presentation.BarcodeWriterGeometry;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;
using SmartHyperMarket.DataEntryManager.Controllers;
using SmartHyperMarket.Common.Models;
using SmartHyperMarket.Common.Controllers;

namespace SmartHyperMarket.DataEntryManager.Views
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {

        string id;
        private Market _market;
        private ProductController _productController;
      
        public AddProduct()
        {
            InitializeComponent();
            _market = Market.getInstance();
            _productController = new ProductController();

            //#region Bardetecting Example
            ////OnBarcodeDetectedDelegate testD = testDelegateFunction; //Testing variable for OnBarcodeDetectedDelegate
            //BarcodeReading.BarcodeReader bcr = new BarcodeReading.BarcodeReader(ref textBoxBarcode, ref player); //Testing variable for BarcodeReader class ( see constructor documentation )
            ////bcr.onBarcodeDetected += testD; //Adding the delegate function to onBarcodeDetected variable at bcr to fire it after detecting barcode emplicitily
            ////If camera opened successfully read barcode and fire onBarcodeDetected delegate
            ////if (bcr.openCamera() == true)
            //bcr.readBarcodes();
            //#endregion
            
            LoadComboxList();
        }

        private void buttonAddProduct_Click(object sender, RoutedEventArgs e)
        {

            Response response = _productController.createProduct(
                new Input("barcode", textBoxBarcode.Text),  
                new Input("description", textboxDescription.Text),
                new Input("name", textBoxName.Text),
                new Input("price", textBoxPrice.Text),
                new Input("weight", textboxWeight.Text),
                new Input("categoryId", getComboboxCategoriesId())
            );

            if (response.State == ResponseState.SUCCESS)
            {
                MessageBox.Show("Product Added Successfuly");
            }
            else
                MessageBox.Show(response.Errors[0].ErrorMessage);
        }

      
        private void clearInputs()
        {
            textBoxBarcode.Text = textboxDescription.Text = textBoxName.Text = textBoxPrice.Text = textboxWeight.Text = "";
            comboBoxcategory.SelectedIndex = -1;
        }

        private void LoadComboxList()
        {
            foreach (Category cat in _market.Categories)
                comboBoxcategory.Items.Add(cat.Name);
        }
        
        private string getComboboxCategoriesId()
        {
            if (comboBoxcategory.SelectedIndex == -1)
                return "";
            else
            {
                string sel = comboBoxcategory.SelectedItem.ToString();
                Category catselected = _market.Categories.Find(category => category.Name == sel);
                return catselected.Id;
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
