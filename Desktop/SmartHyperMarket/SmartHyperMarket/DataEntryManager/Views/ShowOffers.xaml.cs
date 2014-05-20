using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.DataEntryManager.Controllers;
//using SmartHyperMarket.Common.Models;
using SmartHyperMarket.Common.StubModels;
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

namespace SmartHyperMarket.DataEntryManager.Views
{
    /// <summary>
    /// Interaction logic for ShowOffers.xaml
    /// </summary>
    public partial class ShowOffers : Page
    {
        Market market;  
        private OfferController _offerController;


        //public List<Offer> _offers = new List<Offer>();
        //private List<Product> _products = new List<Product>();

        //public void showOffers(List<Offer> offers)
        //{

        //}

        public ShowOffers()
        {

            InitializeComponent();
            Application.Current.MainWindow.Activate();
            market = Market.getInstance();
            market.OnOffersChange = offerlist_onUpdate;
            offersListGrid.ItemsSource = market.Offers;
 
        }


        public void offerlist_onUpdate()
        {
            offersListGrid.Items.Refresh();
        }


        



        private void buttonEditOffer_Click(object sender, RoutedEventArgs e)
        {
            Offer offer = (Offer)offersListGrid.SelectedItem;

            if (offer != null)
            {
                EditOfferWindow offerPopup = new EditOfferWindow(offer);
                offerPopup.Show();


            }
            else
                MessageBox.Show("Please select an offer first to edit");
        }

       
        
        
        private void buttonDeleteOffer_Click(object sender, RoutedEventArgs e)
        {
            Offer offer = (Offer)offersListGrid.SelectedItem;
            _offerController = new OfferController(offer);

            if (offer != null)
            {
                Response response = _offerController.deleteOffer();

                if (response.State == ResponseState.SUCCESS)
                {
                    MessageBox.Show("Offer is successfuly deleted");

                }
                else
                    MessageBox.Show(response.Errors[0].ErrorMessage);


            }
            else
                MessageBox.Show("Please select an offer first to edit");

        
        }

       

       
        
        
        
    


    }
}
