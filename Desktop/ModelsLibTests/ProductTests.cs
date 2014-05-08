using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryManager;
using NUnit.Framework;
namespace DataEntryManager.Tests
{
    [TestFixture()]
    public class ProductTests
    {
        [Test()]
        public void ProductTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ProductTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void updateTest()
        {
            //Arrange
            Product Test_Prod = new Product("pepsi test", "123456789", 6, "1", "1", "desc");
            bool x = Test_Prod.update();
            //Assert
            Assert.IsTrue(x);
        }

        [Test()]
        public void deleteTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void deleteTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void saveTest()
        {
            //Arrange
            Market m = Market.getInstance();
            // next test you should change the entry prameter
            Product p = new Product("last test", "9684113119846196", (float)71.23, "1", "1", "desc");
            p = p.save(m);
            int CatList_Size = 0;

            //Act
            List<Category> List_Cat = Category.LoadCategories(1); //retrive categroies from market 1
            List<Product> List_Prod = new List<Product>();
            Product test_pro = new Product();

            foreach (Category cat in List_Cat)
            {
                if (cat.Id == "1")
                {
                    List_Prod = cat.Products;
                    CatList_Size = cat.Products.Count;
                }
            }

            foreach (Product pro in List_Prod)
            {
                if (pro.Id == p.Id)
                {
                    Assert.AreSame(pro, p);
                }
            };

            //Assert
            Assert.AreNotEqual(CatList_Size, 0);
        }
    }
}
