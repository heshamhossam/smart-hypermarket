using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace DataEntryManager
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class ShowProducts : Page
    {
        private List<Product> _productsList = new List<Product>();

        public ShowProducts()
        {
            InitializeComponent();
            string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/categories/retrieve?market_id=1";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            string data = streamReader.ReadToEnd();

            List<Category> categoriesList = JsonConvert.DeserializeObject<List<Category>>(data);

            for (int i = 0; i < categoriesList.Count; i++)
            {
                 foreach (var product in categoriesList[i].Products)
                {
                    _productsList.Add(product);
                }
            }

            productsListGrid.ItemsSource = _productsList;
            
        }

        private void productsListGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void buttonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productsListGrid.SelectedItem;
            EditProduct editProductWindow = new EditProduct(product);
            editProductWindow.Show();
        }

        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            Product product = (Product)productsListGrid.SelectedItem;

            if (product != null)
                product.delete();
            
        }
    }
}
