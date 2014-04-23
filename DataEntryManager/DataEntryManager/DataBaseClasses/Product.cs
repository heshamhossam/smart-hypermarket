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


        public Product(string name, string barcode, float price, string categoryId)
        {
            this.Name = name;
            this.Barcode = barcode;
            this.Price = price;
            this.Category_id = categoryId;
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



        public void delete(Market market)
        {
            try
            {
                WebClient wb = new WebClient();
                string url = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/delete";
                var data = new NameValueCollection();
                string myString = market.Id.ToString();
                data["marekt"] = myString;


                var response = wb.UploadValues(url, "POST", data);
            }
            catch { MessageBox.Show("deleting error!"); }

        }






        public bool save(Market market)
        {
                string URL = "http://zonlinegamescom.ipage.com/smarthypermarket/public/products/create";

                WebClient webClient = new WebClient();

                NameValueCollection formData = new NameValueCollection();

                formData["name"] = name;

                formData["barcode"] = barcode;

                formData["price"] = price.ToString();

                formData["category_id"] = Category_id;

                formData["market_id"] = market.Id.ToString();

                byte[] responseBytes = webClient.UploadValues(URL, "POST", formData);

                string responsefromserver = Encoding.UTF8.GetString(responseBytes);

                webClient.Dispose();
                if(responsefromserver!=null)
                {
                    return true;
                }
                else 
                    return false;
                }
           
           
        }
    }

