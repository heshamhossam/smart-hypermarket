using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.Controllers
{
    public enum ResponseState { SUCCESS, FAIL };
    /// <summary>
    /// A type which handels the end result of the function and keep track of errors occured during runtime of it
    /// </summary>
    class Response
    {
        private ResponseState _state;

        public Response() { _state = ResponseState.SUCCESS; }

        public ResponseState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        private List<Error> _errors = new List<Error>();
        public List<Error> Errors 
        {
            get
            {
                return _errors;
            }
        }
    }
}
