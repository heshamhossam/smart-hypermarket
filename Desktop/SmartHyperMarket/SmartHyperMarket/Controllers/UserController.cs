using SmartHyperMarket.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Controllers
{
    class UserController
    {
        public Response login(params Input[] inputs)
        {
            Response response = new Response();
            
            response.State = ResponseState.SUCCESS;
            return response;
        }
    }
}
