using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public ShowProducts()
        {
            InitializeComponent();
            string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/categories/retrieve";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            string data = streamReader.ReadToEnd();

            List<Category> categoriesList = JsonConvert.DeserializeObject<List<Category>>(data);
            List<Product> productsList = new List<Product>();

            for (int i = 0; i < categoriesList.Count; i++)
            {

                 foreach (var product in categoriesList[i].Products)
                {
                    productsList.Add(product);
                }
            }
            productsListGrid.ItemsSource = productsList;

            
        }
    }
}
