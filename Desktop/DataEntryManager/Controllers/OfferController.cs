using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataEntryManager.Controllers
{
    class OfferController
    {
        private Offer _offer = new Offer();

        public Response addProductToOffer(params Input[] inputs)
        {
            Response respone = new Response();
            Input productId, productQuantity;

            productId = inputs.Where(input => input.Name == "productId").ElementAt(0);
            productQuantity = inputs.Where(input => input.Name == "productQuantity").ElementAt(0);

            if(productId == null || productId.Value == "")
                respone.Errors.Add(new Error("Product ID can't be empty."));
            if(productQuantity == null || productQuantity.Value == "")
                respone.Errors.Add(new Error("Product quantity can't be empty."));

            if (respone.Errors.Count > 0)
                respone.State = ResponseState.FAIL;
            else
            {

                Product product = new Product();

                product.Id = productId.Value;

                int productQuantityInt;
                if (int.TryParse(productQuantity.Value, out productQuantityInt) == true)
                    product.Quantity = productQuantityInt;
                else
                    respone.Errors.Add(new Error("ID isn't integer"));

                _offer.Products.Add(product);
            }

            return respone;
        }
        
        public Response createOffer(params Input[] inputs)
        {
            Response respone = new Response();

            Input name, price, teaser;

            name = inputs.Where(input => input.Name == "name").ElementAt(0);
            price = inputs.Where(input => input.Name == "price").ElementAt(0);
            teaser = inputs.Where(input => input.Name == "teaser").ElementAt(0);

            if (name == null || name.Value == "")
                respone.Errors.Add(new Error("Offer name can't be empty."));
            if (price == null || price.Value == "")
                respone.Errors.Add(new Error("Offer price can't be empty."));
            if(teaser == null || teaser.Value == "")
                respone.Errors.Add(new Error("Offer teaser can't be empty."));

            if (respone.Errors.Count > 0)
                respone.State = ResponseState.FAIL;
            else
            {
                Offer offerSaved = _offer.save(Market.getInstance());

                if (offerSaved == null)
                {
                    
                    respone.Errors.Add(new Error("Unknown error happend while saving product, please try again later"));
                    respone.State = ResponseState.FAIL;
                }
                else
                {
                    respone.State = ResponseState.SUCCESS;
                }
            }

            return respone;
        }
    }
}

