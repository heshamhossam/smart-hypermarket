using DataEntryManager.Controllers;
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

namespace DataEntryManager
{
    /// <summary>
    /// Interaction logic for AddOffer.xaml
    /// </summary>
    public partial class AddOffer : Page
    {
        private Market market;
        List<Product> offerlist;
        List<string> productid;
        List<string> productquantatiy;
        private OfferController _offercontroller;
        float totalofferprice = 0;
        
        public AddOffer()
        {
            InitializeComponent();
            market = Market.getInstance();
            offerlist = new List<Product>();
           // productsid = new List<String>();
          //  productsquantatiy = new List<String>();
            productid = new List<string>();
            productquantatiy = new List<string>();
           
            LoadCategoriesList();
        }
        private void LoadCategoriesList()
        {
            foreach (Category cat in market.Categories)
                categorylist.Items.Add(cat.Name);
        }
        private void LoadProductsList()
        {
            Category cat = market.Categories.Where(x => x.Name==categorylist.SelectedItem.ToString()).ElementAt(0);
            foreach(Product p in cat.Products)
            {
                productlist.Items.Add(p.Name);
            }
        }

        private void categorylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            productlist.Items.Clear();
            LoadProductsList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            productoffer.Items.Add(productlist.SelectedItem);
            Category cat = market.Categories.Where(x => x.Name == categorylist.SelectedItem.ToString()).ElementAt(0);
            foreach (Product p in cat.Products)
            {
               if(p.Name==productlist.SelectedItem.ToString())
               {
                  // p.Quantity = int.Parse(quantatiy.Text);
               //    totalofferprice += p.Price*p.Quantity;
                   totalprice.Text = totalofferprice.ToString();
                   offerlist.Add(p);
                   productid.Add(p.Id);
                   productquantatiy.Add(quantatiy.ToString());

               }
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Response response = _offercontroller.createOffer(
                new Input("productsids",productid),
                new Input("productsquantaties",productquantatiy),
                new Input("teaser",textBoxTeaser.Text),
                new Input("name",offername.Text),
                new Input("offerprice",totalprice.Text)
                );
            if(response.State==ResponseState.SUCCESS)
            {
                MessageBox.Show("Your Porduct Added Successfully");
            }
            else
            {
                MessageBox.Show(response.Errors[0].ErrorMessage);
            }
        }

     
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
       //   Offer o;
            Offer offer = new Offer(offerlist, textBoxTeaser.Text, offername.Text, int.Parse(totalprice.Text));
            offer.save();
           
         
        }
    }
}
