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
using SmartHyperMarket.Common.Models;
using SmartHyperMarket.DataEntryManager.Controllers;
using SmartHyperMarket.Common.Controllers;

namespace SmartHyperMarket.DataEntryManager.Views
{
    /// <summary>
    /// Interaction logic for AddOffer.xaml
    /// </summary>
    public partial class AddOffer : Page
    {
        private Market market;
        private OfferController _offercontroller = new OfferController();
        
        public AddOffer()
        {
            InitializeComponent();
            grid1.Visibility = Visibility.Hidden;
            market = Market.getInstance();

           
            LoadCategoriesList();      
    
            List<Offer> a = Offer.all(Market.getInstance());


        }

        private void LoadCategoriesList()
        {
            foreach (Category cat in market.Categories)
                comboBoxCategories.Items.Add(cat.Name);
        }

        private void LoadProductsList()
        {
            Category cat = market.Categories.Where(x => x.Name == comboBoxCategories.SelectedItem.ToString()).ElementAt(0);
            foreach(Product p in cat.Products)
            {
                comboBoxProducts.Items.Add(p.Name);
            }
        }

        private void categorylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxProducts.Items.Clear();
            LoadProductsList();
        }

        private void buttonAddToOffer_Click(object sender, RoutedEventArgs e)
        {
            Product product = market.Products.Where(p => p.Name == comboBoxProducts.SelectedItem.ToString()).ElementAt(0);

            Response response = _offercontroller.addProductToOffer(
                new Input("productId", product.Id),
                new Input("productQuantity", textBoxQuantity.Text)
            );

            if (response.State == ResponseState.SUCCESS)
            {
                //add product name to list box and its quantity
                listBoxProductOffer.Items.Add(comboBoxProducts.SelectedItem + "(" + textBoxQuantity.Text + ")");
                textBoxQuantity.Text = "";
            }
            else
                MessageBox.Show(response.Errors[0].ErrorMessage);

        }

        private void buttonSubmitOffer_Click(object sender, RoutedEventArgs e)
        {
            Response response = _offercontroller.createOffer(
                new Input("name", textBoxName.Text),
                new Input("price", textBoxOfferPrice.Text),
                new Input("teaser", textBoxTeaser.Text)
            );

            if (response.State == ResponseState.SUCCESS)
            {
                clearInputs();
                MessageBox.Show("Offer Added successfuly");
            }
            else
                MessageBox.Show(response.Errors[0].ErrorMessage);
        }

        private void clearInputs()
        {

        }

        private void buttonCreateOffer_Click(object sender, RoutedEventArgs e)
        {
            grid2.Visibility = Visibility.Hidden;
            grid1.Visibility = Visibility.Visible;
        }
    }
}
