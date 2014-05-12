using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager.Controllers
{
    class OfferController
    {
           public Response createOffer(params Input[] inputs)
            {
               Response respone = new Response();
               Input productsids,productsquanatiy,offername,offerteaser,offerprice;
               productsids=inputs.Where(input=>input.Name=="productsids").ElementAt(0);
               productsquanatiy= inputs.Where(input=>input.Name=="productsquantaties").ElementAt(0);
               offername= inputs.Where(input=>input.Name=="name").ElementAt(0);
               offerteaser= inputs.Where(input=>input.Name=="teaser").ElementAt(0);
               offerprice= inputs.Where(input=>input.Name=="offerprice").ElementAt(0);
                //implement this ya ess
               return respone;
            
            }
        }
    }

