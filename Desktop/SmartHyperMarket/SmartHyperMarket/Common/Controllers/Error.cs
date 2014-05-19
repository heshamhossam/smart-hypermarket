using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.Controllers
{
    /// <summary>
    /// Handel errors of the application occured during runtime
    /// </summary>
    public class Error
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
}
