using SmartHyperMarket.Common.Models;
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
        private List<Offer> _offers = new List<Offer>();
        public ShowOffers()
        {
            InitializeComponent();

            
        }

        public void showOffers(List<Offer> offers)
        {

        }
    }
}
