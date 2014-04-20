using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager
{
    interface ICategory
    {
        string CategoryID { get; set; }
        string CategoryName { get; set; }
        List<Product> Products { get; set; }
    }
}
