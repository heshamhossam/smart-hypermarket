using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.StubModels
{
    interface IMarket
    {

        List<Product> Products { get; }

        List<Category> Categories { get; }

        List<Order> Orders { get; }

        List<Employee> Employees { get; }

        int Id { get; }

    }
}
