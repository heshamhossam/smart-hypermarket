using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using StorageManager;

namespace DataEntryManager.Controllers
{
    class MainWindow
    {
        public static void deleteTabItems(ref TabControl tabControl, ref Frame tabFrame)
        {
            for (int i = 0; i < tabControl.Items.Count; i++)
            {
                if (tabControl.Items.GetItemAt(i) != tabFrame)
                {
                    tabControl.Items.RemoveAt(i);
                    i = 0;
                }
            }
        }

        public static void assignLoginTrigger(string value, ref Frame tabFrame, ref TabControl tabControl)
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
        }
    }
}
