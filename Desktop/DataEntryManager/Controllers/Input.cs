using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager.Controllers
{
    class Input
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

            set
            {
                _value = value;
            }
        }

        public Input(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
