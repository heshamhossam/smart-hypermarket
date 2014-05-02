using StorageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager
{
    interface IMarket
    {

        List<Product> Products { get; }


        List<Category> Categories { get; }

        List<Order> Orders { get; }

        int Id { get; }

    }
}
