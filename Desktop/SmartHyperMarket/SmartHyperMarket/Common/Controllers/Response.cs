using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.Controllers
{
    public enum ResponseState { SUCCESS, FAIL };

    
    class Response
    {
        private ResponseState _state;
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
