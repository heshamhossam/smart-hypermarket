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
        float Price { get; set; }
        string Created_at { get; set; }
        string Updated_at { get; set; }
        string Category_id { get; set; }
        string Description { get; set; }
        string Weight { get; set; }

        //constructor
        //@name: string contains the name of the product
        //@category id: integer contains the id of the cateogry the product will go under
        //@price: integer contains the price of the product in the market
        //@barcode: string contains the bar code of product
        //public IProduct(string name, int categoryId, int price, string barcode);

        /// <summary>
        /// Saves the current fields values into the database
        /// </summary>
        bool update();

        /// <summary>
        /// Delete the whole product from database
        /// </summary>
        void delete();

        /// <summary>
        /// Save new Product to the database
        /// </summary>
        /// <param name="market">Market who are performing the saving</param>
        Product save(Market market);


        // <summary>
        /// Delete the whole product in database related to the market
        /// </summary>
        /// <param name="market">Market to delete product from</param>
        bool delete(Market market);

    }
}
