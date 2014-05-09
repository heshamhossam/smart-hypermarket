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

namespace DataEntryManager
{
    /// <summary>
    /// Interaction logic for Administrator.xaml
    /// </summary>
    public partial class Login : Page
    {
        public event Action<string> Check;

        public Login()
        {
            InitializeComponent(); 
        }

        /// <summary>
        /// send messages to MainWindow depending on current user entered information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Check != null)
            {
                string role = Controllers.Login.userRole(username.Text, password.Text);
                if (role != null)
                    Check(role);
                else
                    MessageBox.Show("Username or Password is wrong");
            }
        }
    }
}
