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
        private Product _product = new Product();

        public Product Product 
        {
            set { _product = value; }
        }
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

                Product productSaved = Market.getInstance().addProduct(product);

                if (productSaved == null)
                {
                    response.Errors.Add(new Error("Unknown error happend while saving product, please try again later"));
                    response.State = ResponseState.FAIL;
                }
                else
                    response.State = ResponseState.SUCCESS;

            }

            return response;
        }
    
        public Response editProduct(Product product,params Input[] inputs)
        {
            Response response = new Response();
            Input name, barcode, price;
            name = inputs.Where(input => input.Name == "name").ElementAt(0);
            barcode = inputs.Where(input => input.Name == "barcode").ElementAt(0);
            price = inputs.Where(input => input.Name == "price").ElementAt(0);
            if(name.Value=="")
            {
                response.Errors.Add(new Error("Please add the product name"));
            }
            if(barcode.Value=="")
            {
                response.Errors.Add(new Error("Please add the product barcode"));
            }
            if(price.Value=="")
            {
                response.Errors.Add(new Error("Please add the product price"));
            }
            if(response.Errors.Count>0)
            {
                response.State = ResponseState.FAIL;
            }
            else
            {
                response.State = ResponseState.SUCCESS;
              bool check_productedit =  Market.getInstance().editProduct(product);  
                if(check_productedit==false)
                {
                    response.Errors.Add(new Error("Error happen while editing a product please check later"));
                    response.State = ResponseState.FAIL;


                }
                else
                {
                    response.State = ResponseState.SUCCESS;
                }
            }
            return response;
        }

        public Response deleteProduct(Product product)
        {
            Response response = new Response();
            if(product!=null)
            {
             bool check_productdeleted =  Market.getInstance().deleteProduct(product);
             if(check_productdeleted==true)
             {
                 response.State = ResponseState.SUCCESS;
             }
             else
             {
                 response.Errors.Add(new Error("Error Happen in the server please try later on"));
                 response.State = ResponseState.FAIL; 
             }
            }
            else
            {
                response.Errors.Add(new Error("There Is No Product Selected To Delete"));
                response.State = ResponseState.FAIL;
            }
            return response;
        }
    }
}
