using SmartHyperMarket.Common.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Controllers
{
    /// <summary>
    /// Control user behavior and functionality
    /// </summary>
    class UserController
    {
        /// <summary>
        /// Login user into server using his information
        /// </summary>
        /// <param name="inputs">List of inputs : username, password</param>
        /// <returns>Result of runing the function</returns>
        public Response login(params Input[] inputs)
        {
            Response response = new Response();
            
            response.State = ResponseState.SUCCESS;
            return response;
        }
    }
}
