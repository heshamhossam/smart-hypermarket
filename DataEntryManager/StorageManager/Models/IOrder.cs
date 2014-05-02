using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryManager;

namespace StorageManager.Models
{


    interface IOrder
    {
        string State { get; set; }
        string Id { get; set; }
        string ConfirmationCode { get; set; }
        List<Product> Products { get; set; }

        void update();



    }
}
