using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.StubModels
{
    public abstract class Model<ModelType>
    {
        protected Market _market;

        private static string _webserviceURLParent = "http://zonlinegamescom.ipage.com/smarthypermarket/public";
        private static string _webserviceMockURLParent = "http://zonlinegamescom.ipage.com/smarthypermarket/public/mocks";

        public static string webServiceParent
        {
            get
            {
                return _webserviceURLParent;
            }
        }

        abstract public ModelType save();

        abstract public bool update();

        abstract public bool delete();
    }
}
