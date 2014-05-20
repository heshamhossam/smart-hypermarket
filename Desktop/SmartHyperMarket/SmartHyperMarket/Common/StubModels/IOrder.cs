using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHyperMarket;

namespace SmartHyperMarket.Common.StubModels
{
    interface IOrder
    {
        string Id { get; set; }
        string State { get; set; }
        string Market_id { get; set; }
        string User_id { get; set; }
        string Confirmation_code { get; set; }
        string Created_at { get; set; }
        string Updated_at { get; set; }
        List<Product> Products { get; set; }
    }
}
