using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntryManager
{
    public class Product : IProduct
    {
        private string id;
        private string name;
        private string barcode;
        private string price;
        private string created_at;
        private string updated_at;
        private string category_id;


        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;
            }
        }

        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public string Created_at
        {
            get
            {
                return created_at;
            }
            set
            {
                created_at = value;
            }
        }

        public string Updated_at
        {
            get
            {
                return updated_at;
            }
            set
            {
                updated_at = value;
            }
        }

        public string Category_id
        {
            get
            {
                return category_id;
            }
            set
            {
                category_id = value;
            }
        }





        public void update()
        {
            throw new NotImplementedException();
        }

        string IProduct.Id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IProduct.Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IProduct.Barcode
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IProduct.Price
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IProduct.Created_at
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IProduct.Updated_at
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string IProduct.Category_id
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void IProduct.update()
        {
            throw new NotImplementedException();
        }

        public void delete()
        {
            //throw new NotImplementedException();
        }


        
    }
}
