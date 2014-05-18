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
using SmartHyperMarket.Common.Models;

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
                List<Employee> employees = SmartHyperMarket.Common.Models.Market.getInstance().Employees;
                Employee loginEmployee = employees.Find(employee => employee.authenticate(textBoxUsername.Text, passwordBoxPassword.SecurePassword.ToString()));
                #region mock_employee
                loginEmployee = new Employee();
                loginEmployee.Role = EmployeeRole.DATA_ENTRY;
                #endregion
                if (loginEmployee == null)
                    MessageBox.Show("Employees database hasn't fully loaded into the application");
                else if (!loginEmployee.hasRole())
                    MessageBox.Show("Employee has no role");
                else
                {
                    //open the window related to Employee role and hide log in window
                    switch (loginEmployee.Role)
                    {
                        case EmployeeRole.ADMIN:
                            break;
                        case EmployeeRole.DATA_ENTRY:
                            SmartHyperMarket.DataEntryManager.Views.MainWindow dataEntryWindow = new DataEntryManager.Views.MainWindow();
                            dataEntryWindow.Show();
                            Application.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
                            break;
                        case EmployeeRole.STORAGE:
                            SmartHyperMarket.StorageManager.Views.MainWindow storageWindow = new StorageManager.Views.MainWindow();
                            storageWindow.Show();
                            Application.Current.MainWindow.Visibility = System.Windows.Visibility.Hidden;
                            break;
                        default:
                            MessageBox.Show("Employee role is not defined to application system");
                            break;
                    }
                }
            }
            else
                MessageBox.Show(responseLogin.Errors[0].ErrorMessage);
        }


    }
}
