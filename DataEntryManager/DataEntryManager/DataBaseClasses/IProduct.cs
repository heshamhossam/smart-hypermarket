using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager
{
    public interface IProduct
    {
        string Id { get; set; }
        string Name { get; set; }
        string Barcode { get; set; }
        string Price { get; set; }
        string Created_at { get; set; }
        string Updated_at { get; set; }
        string Category_id { get; set; }

        //constructor
        //@name: string contains the name of the product
        //@category id: integer contains the id of the cateogry the product will go under
        //@price: integer contains the price of the product in the market
        //@barcode: string contains the bar code of product
        //public IProduct(string name, int categoryId, int price, string barcode);

        /// <summary>
        /// Saves the current fields values into the database
        /// </summary>
        void save();

    }
}
