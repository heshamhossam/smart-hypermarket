using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager
{
    public class Market : IMarket
    {
        private Market()
        {
            ;
        }

        /// <summary>
        /// get instance of the static object market
        /// </summary>
        /// <returns>market object</returns>
        public static Market getInstance()
        {
            return new Market();
        }



        public List<Product> Products
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public List<Product> Categories
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                return 1;
            }
            set
            {
                ;
            }
        }
    }
}
