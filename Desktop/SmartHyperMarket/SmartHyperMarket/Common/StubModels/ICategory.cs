using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.StubModels
{
    interface ICategory
    {
        string Id { get; set; }
        string Name { get; set; }
        string Created_at { get; set; }
        string Updated_at { get; set; }
        int? Category_id { get; set; }
        List<Product> Products { get; set; }
        
    }
}
