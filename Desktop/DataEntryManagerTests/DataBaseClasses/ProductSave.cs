using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataEntryManager.Tests
{
    [TestClass]
    public class ProductSave
    {
        [TestMethod]
        public void ProductSaveTest()
        {
            //Arrange
            Product Test_Prod = new Product("pepsi test", "123456789",6,"1");
            int CatList_Size=0;

            //Act
            List<Category> List_Cat = Category.LoadCategories(1); //retrive categroies from market 1
            List<Product> List_Prod = new List<Product>();

            foreach (Category cat in List_Cat)
            {
                if (cat.CategoryID == "1")
                {
                    List_Prod = cat.Products;
                    CatList_Size = cat.Products.Count;
                }
            };

            //Assert

            
            Assert.AreEqual(List_Prod, Test_Prod);
            Assert.AreNotEqual(CatList_Size, 0);
          

        }
    }
    }
