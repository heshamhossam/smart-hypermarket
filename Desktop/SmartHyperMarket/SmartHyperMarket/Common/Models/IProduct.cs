using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.Models
{
    public interface IProduct
    {
        string Id { get; set; }
        string Name { get; set; }
        string Barcode { get; set; }
        float Price { get; set; }
        string Created_at { get; set; }
        string Updated_at { get; set; }
        string Category_id { get; set; }
        string Description { get; set; }
        string Weight { get; set; }


    }
}
