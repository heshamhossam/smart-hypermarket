 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using SmartHyperMarket.Common.Controllers;
using SmartHyperMarket.Common.Models;
//using SmartHyperMarket.Common.StubModels;
using SmartHyperMarket.DataEntryManager.Views;

namespace SmartHyperMarket.DataEntryManager.Controllers
{
    /// <summary>
    /// Handel the logic operations dealing with offers and it's related functionality
    /// </summary>
    public class OfferController
    {
        private Offer _offer = new Offer(Market.getInstance());

        public OfferController()
        { }

        public OfferController(Offer offer)
        {
            _offer = offer;
        }

        /// <summary>
        /// Add new product with it's quantity to controller of the offer
        /// </summary>
        /// <param name="inputs">List of inputs : productID and productQuantity</param>
        /// <returns>Result of runing the function</returns>
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

                Product product = new Product(Market.getInstance());

                product.Id = productId.Value;

                int productQuantityInt;
                if (int.TryParse(productQuantity.Value, out productQuantityInt) == true)
                    product.Quantity = productQuantityInt;
                else
                {
                    respone.Errors.Add(new Error("Quantity do not represent integer value."));
                    respone.State = ResponseState.FAIL;
                }

                _offer.Products.Add(product);
            }

            return respone;
        }
        
        /// <summary>
        /// Create the controller offer constructed in the system
        /// </summary>
        /// <param name="inputs">List of inputs : name, price and teaser</param>
        /// <returns>Result of runing the function</returns>
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
                _offer.Name = name.Value;
                _offer.Price = (price.Value);
                _offer.Teaser = teaser.Value;

                bool offerSaved = Market.getInstance().addOffer(_offer);

                if (!offerSaved)
                {
                    respone.Errors.Add(new Error("Unknown error happend while saving product, please try again later."));
                    respone.State = ResponseState.FAIL;
                }
                else
                {
                    respone.State = ResponseState.SUCCESS;
                }
            }

            return respone;
        }
        
        /// <summary>
        /// Edit the offer of offer controller instance
        /// </summary>
        /// <param name="inputs">List of edited inputs : name, price and teaser</param>
        /// <returns>Result of runing the function</returns>
        public Response editOffer(params Input[] inputs)
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
            if (teaser == null || teaser.Value == "")
                respone.Errors.Add(new Error("Offer teaser can't be empty."));

            if (respone.Errors.Count > 0)
                respone.State = ResponseState.FAIL;
            else
            {
                _offer.Name = name.Value;
                _offer.Price = (price.Value);
                _offer.Teaser = teaser.Value;
                bool offerSaved = Market.getInstance().updateOffer(_offer);

                if (!offerSaved)
                {

                    respone.Errors.Add(new Error("Unknown error happend while saving offer, please try again later"));
                    respone.State = ResponseState.FAIL;
                }
                else
                {
                    respone.State = ResponseState.SUCCESS;
                }
            }

            return respone;
        }

        /// <summary>
        /// Delete the offer currently held by the offer controller
        /// </summary>
        /// <returns>Result of runing the function</returns>
        public Response deleteOffer()
        {
            Response respone = new Response();
            if (_offer == null)
            {
                respone.Errors.Add(new Error("Offer does not exist"));
                respone.State = ResponseState.FAIL;
            }

            if (Market.getInstance().deleteOffer(_offer))
                respone.State = ResponseState.SUCCESS;
            else
            {
                respone.Errors.Add(new Error("Unknown error happend while saving offer, please try again later"));
                respone.State = ResponseState.FAIL;
            }
            return respone;
        }

        public Response showOffers(ShowOffers showOffersPage)
        {
            Response response = new Response();

            showOffersPage.show(Market.getInstance().Offers);

            response.State = ResponseState.SUCCESS;
            return response;
        }
    }
}

