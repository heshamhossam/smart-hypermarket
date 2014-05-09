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
using StorageManager;
using System.Windows.Navigation;

using Controllers = DataEntryManager.Controllers;


namespace DataEntryManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            
            InitializeComponent();
            switchToLogin();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Controllers.MainWindow.deleteTabItems(ref tabControl, ref tabFrame);
            switchToLogin();
        }

        private void switchToLogin()
        {
            Login login = new Login();

            tabFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            tabFrame.Content = login;
            login.Check += value =>
            {
                if (value == "storageManager")
                {
                    TabItem ordersPageTab = new TabItem();
                    ordersPageTab.Header = "Orders";
                    OrdersPage ordersPage = new OrdersPage();
                    Frame ordersPageFrame = new Frame();
                    ordersPageFrame.Content = ordersPage;
                    ordersPageTab.Content = ordersPageFrame;

                    tabFrame.Content = ordersPage; //first tab to appear

                    TabItem orderCheckPageTab = new TabItem();
                    orderCheckPageTab.Header = "Open Order";
                    OrderCheckPage orderCheckPage = new OrderCheckPage();
                    Frame orderCheckPageFrame = new Frame();
                    orderCheckPageFrame.Content = orderCheckPage;
                    orderCheckPageTab.Content = orderCheckPageFrame;

                    tabControl.Items.Add(ordersPageTab);
                    tabControl.Items.Add(orderCheckPageTab);
                }
                else if (value == "dataEntryManager")
                {
                    TabItem showProductsTab = new TabItem();
                    showProductsTab.Header = "Show Products";
                    ShowProducts showProducts = new ShowProducts();
                    Frame showProductsFrame = new Frame();
                    showProductsFrame.Content = showProducts;
                    showProductsTab.Content = showProductsFrame;

                    tabFrame.Content = showProducts; //first tab to appear

                    TabItem addProductTab = new TabItem();
                    addProductTab.Header = "Add Product";
                    AddProduct addProduct = new AddProduct();
                    Frame addProductFrame = new Frame();
                    addProductFrame.Content = addProduct;
                    addProductTab.Content = addProductFrame;

                    tabControl.Items.Add(showProductsTab);
                    tabControl.Items.Add(addProductTab);
                }
                else if (value == "admin")
                {
                    //to be implemented as admin control panel
                }
            };
            //login.Check += value => Controllers.MainWindow.assignLoginTrigger(ref value, ref tabFrame, ref tabControl);
        }
    }
}
