using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager.Controllers
{
    public enum ResponseState { SUCCESS, FAIL };

    class Error
    {
        protected string _errorMessage;
        public string ErrorMessage 
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }

        public Error(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }


    }

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
