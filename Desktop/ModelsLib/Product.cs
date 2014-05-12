using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace DataEntryManager
{
    public class Product : IProduct
    {
        private string id;
        private string name;
        private string barcode;
        private float price;
        private string created_at;
        private string updated_at;
        private string category_id;
        private int quantity;
        private string description;
        private string weight;
        public string Description
            {
            get {return description;}
            set{description = value; }
        }

        public string Weight
         {
            get{return weight;}
           set {weight = value;}
        }

        public Product()
        {

        }

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

        public float Price
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

        public int Quantity 
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public Product(string name, string barcode, float price, string categoryId, string weight, string description)
        {
            this.Name = name;
            this.Barcode = barcode;
            this.Price = price;
            this.Category_id = categoryId;
            this.weight = weight;
            this.description = description;
        }


        public bool update()
        {
            try
            {

                string URL = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/edit";

                WebClient webClient = new WebClient();

                NameValueCollection formData = new NameValueCollection();

                formData["id"] = id;

                formData["name"] = name;

                formData["barcode"] = barcode;

                formData["market_id"] = "1";

                formData["price"] = price.ToString();

                formData["weight"] = weight;

                formData["description"] = description;

                byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);

                string responsefromserver = Encoding.UTF8.GetString(responseBytes);

                webClient.Dispose();

                if(responsefromserver == null)
                    return false;
                else 
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }

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
        string IProduct.Weight
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
        string IProduct.Description
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

        float IProduct.Price
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

        public void delete()
        {
            try
            {
                WebClient wb = new WebClient();
                string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/delete";
                var data = new NameValueCollection();
                data["id"] = id;


                var response = wb.UploadValues(url, "POST", data);
            }
            catch { MessageBox.Show("deleting error!"); }

        }



        public bool delete(Market market)
        {
            try
            {
                WebClient wb = new WebClient();
                string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/delete";
                var data = new NameValueCollection();
                
                data["market_id"] = market.Id.ToString();
                data["id"] = id;

                byte[] responseBytes = wb.UploadValues(url, "POST", data);

                string responsefromserver = Encoding.UTF8.GetString(responseBytes);

                if (responsefromserver != null)
                    return true;

                return false;
                
            }
            catch { return false; }

        }






        public Product save(Market market)
        {

              string URL = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/create";

                WebClient webClient = new WebClient();

                NameValueCollection formData = new NameValueCollection();

                formData["name"] = name;

                formData["barcode"] = barcode;

                formData["price"] = price.ToString();

                formData["category_id"] = Category_id;

                formData["market_id"] = market.Id.ToString();

                formData["weight"] = weight;

                formData["description"] = description;

                byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);

                string responsefromserver = Encoding.UTF8.GetString(responseBytes);
                Product p = JsonConvert.DeserializeObject<Product>(responsefromserver);

                id = p.Id;
                created_at = p.created_at;
                updated_at = p.updated_at;
                
                webClient.Dispose();
                if(responsefromserver!=null)
                    return this;
                else 
                    return null;
            }
           
           
        }
    }

