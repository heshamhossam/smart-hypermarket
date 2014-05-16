using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.Controllers;
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

namespace SmartHyperMarket.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private UserController _userController = new UserController();
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            Response responseLogin = _userController.login();

            if (responseLogin.State == ResponseState.SUCCESS)
            {
                //load employee and check his role
                //then open the window you window you want and hide this one
                SmartHyperMarket.DataEntryManager.Views.MainWindow dataEntryWindow = new DataEntryManager.Views.MainWindow();
                dataEntryWindow.Show();
                Application.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
            }
            else
                MessageBox.Show(responseLogin.Errors[0].ErrorMessage);
        }


    }
}
