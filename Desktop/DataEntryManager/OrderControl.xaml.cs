﻿using DataEntryManager;
using FirstFloor.ModernUI.Windows;
using StorageManager.Models;
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

using Controllers = DataEntryManager.Controllers;

namespace StorageManager
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl, IContent
    {
        private Order order = new Order();
        public OrderControl()
        {
            InitializeComponent();
        }

        private void buttonServed_Click(object sender, RoutedEventArgs e)
        {
            Controllers.OrderControl.changeToServed(ref order);
            //order.State = Order.READY;
            //order.update(null);
        }

        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            string id = e.Fragment;
            Controllers.OrderControl.showOrder(id, ref productsList, ref order);
            //Market market = Market.getInstance();
            //order = market.Orders.Find(i => i.Id == id);
            //if (order != null)
            //{
            //    Controllers.OrderControl.show(order, ref productsList);
            //    //productsList.ItemsSource = order.Products;
            //}
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {

        }

        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            
        }
    }
}
