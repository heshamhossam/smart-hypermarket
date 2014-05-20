using SmartHyperMarket.Common.Controllers;
//using SmartHyperMarket.Common.Models;
using SmartHyperMarket.Common.StubModels;
using SmartHyperMarket.DataEntryManager.Controllers;
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
using System.Windows.Shapes;

namespace SmartHyperMarket.DataEntryManager.Views
{
    /// <summary>
    /// Interaction logic for EditOfferWindow.xaml
    /// </summary>
    public partial class EditOfferWindow : Window
    {
        private Offer _offer = new Offer();
        private OfferController _offerController;
        

        public EditOfferWindow(Offer offer)
        {
            InitializeComponent();
            _offer = offer;
            _offerController = new OfferController(_offer);
            

            ShowOffer(_offer);
        }

        public void ShowOffer(Offer offer)
        {
            textBoxOfferName.Text = offer.Name;
            textBoxOfferTeaser.Text = offer.Teaser;
            textBoxOfferPrice.Text = offer.Price;

        }

        private void buttonOfferEdit_Click(object sender, RoutedEventArgs e)
        {

            Response response = _offerController.editOffer(
                new Input("name", textBoxOfferName.Text),
                new Input("teaser", textBoxOfferTeaser.Text),
                new Input("price", textBoxOfferPrice.Text)
            );
            
            if (response.State == ResponseState.SUCCESS)
            {
                MessageBox.Show("Offer is successfuly updated");
                this.Close();
            }
            else
                MessageBox.Show(response.Errors[0].ErrorMessage);
        }
    }
}
