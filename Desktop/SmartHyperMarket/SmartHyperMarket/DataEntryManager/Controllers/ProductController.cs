using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.Common.Models;

namespace SmartHyperMarket.DataEntryManager.Controllers
{
    /// <summary>
    /// Handel of the logic operations related with product
    /// </summary>
    class ProductController
    {
        /// <summary>
        /// Create new product in the system
        /// </summary>
        /// <param name="inputs">List of inputs : name, barcode, price, categoryId, weight and description</param>
        /// <returns>Result of runing the function</returns>
        public Response createProduct(params Input[] inputs)
        {
            Response response = new Response();
            Input name, barcode, price, categoryId, weight, description;

            name = inputs.Where(input => input.Name == "name").ElementAt(0);
            barcode = inputs.Where(input => input.Name == "barcode").ElementAt(0);
            price = inputs.Where(input => input.Name == "price").ElementAt(0);
            categoryId = inputs.Where(input => input.Name == "categoryId").ElementAt(0);
            weight = inputs.Where(input => input.Name == "weight").ElementAt(0);
            description = inputs.Where(input => input.Name == "description").ElementAt(0);

            if (name.Value == "")
                response.Errors.Add(new Error("Product Name can't be empty."));
            if (barcode.Value == "")
                response.Errors.Add(new Error("Product Barcode can't be empty."));
            if (price.Value == "")
                response.Errors.Add(new Error("Product Price can't be empty."));
            if (categoryId.Value == "")
                response.Errors.Add(new Error("Product Category can't be empty."));
            if (weight.Value == "")
                response.Errors.Add(new Error("Product Weight can't be empty."));
            if (description.Value == "")
                response.Errors.Add(new Error("Product Description can't be empty."));


            if (response.Errors.Count > 0)
                response.State = ResponseState.FAIL;
            else
            {
                Product product = new Product(
                    name.Value, barcode.Value, float.Parse(price.Value), categoryId.Value, weight.Value, description.Value, Market.getInstance()
                );

                Product productSaved = product.save();

                if (productSaved == null)
                {
                    response.Errors.Add(new Error("Unknown error happend while saving product, please try again later"));
                    response.State = ResponseState.FAIL;
                }
                else
                {
                    Market.getInstance().Products.Add(productSaved);
                    Market.getInstance().onProductsChangeHandler();
                    response.State = ResponseState.SUCCESS;
                }

            }

            return response;
        }
    }
}
