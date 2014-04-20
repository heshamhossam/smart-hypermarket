using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager
{
    class Category : ICategory
    {
        private string categoryID;
        private string categoryName;
        private List<Product> products;
        public string CategoryID
        {
            get
            {
                return categoryID;
            }
            set
            {
                categoryID = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }
    }
}
