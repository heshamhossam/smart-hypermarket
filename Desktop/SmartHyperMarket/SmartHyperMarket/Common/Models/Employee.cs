using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHyperMarket.Common.Models
{
    enum EmployeeRole
    {
        DATA_ENTRY, STORAGE, ADMIN
    }

    class Employee : Model<Employee>
    {
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password;
        private EmployeeRole _role;

        public bool authenticate(string username, string password)
        {
            if (_username == username && _password == password)
                return true;

            return false;
        }

        public override Employee save()
        {
            return default(Employee);
        }

        public override bool update()
        {
            return false;
        }

        public override bool delete()
        {
            return false;
        }
    }
}
