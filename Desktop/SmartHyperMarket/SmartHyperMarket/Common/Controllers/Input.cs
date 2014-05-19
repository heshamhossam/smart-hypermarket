using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.Controllers
{
    /// <summary>
    /// Work as a container for diffirent inputss
    /// </summary>
    public class Input
    {
        string _name;
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        string _value;
        public string Value
        {
            get
            {
                return _value;
            }
        }


        public Input(string name, string value)
        {
            Name = name;
            _value = value;
        }
    }
}
