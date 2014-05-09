using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager.Controllers
{
    class Login
    {
        /// <summary>
        /// check in the database the role of user assigned with username and password passed
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>"storageManager", "dataEntryManager" or "admin" as a role and null if no user assigned with this data</returns>
        public static string userRole(string username, string password)
        {
            //if (notfound)
            //    return null;
            //else if (storage_mager)
            return "storageManager";
            //else if (data_entry_manager)
            //    return "dataEntryManager";
            //else if (admin)
            //    return "admin";
        }
    }
}
