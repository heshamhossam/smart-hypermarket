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
    /// Interaction logic for OrderCheckPage.xaml
    /// </summary>
    public partial class OrderCheckPage : Page
    {
        public OrderCheckPage()
        {
            InitializeComponent();
        }

        private void buttonOpenOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderPopup = Controllers.OrderCheckPage.getOrderWindow(id.Text, confirmationCode.Text);

            if (orderPopup != null)
                orderPopup.Show();
            else
                MessageBox.Show("Invaild Confirmation Code!");
        }
    }
}