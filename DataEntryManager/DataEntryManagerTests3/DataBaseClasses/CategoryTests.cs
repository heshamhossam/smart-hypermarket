﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataEntryManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace DataEntryManager.Tests
{
    [TestClass()]
    public class CategoryTests
    {
<<<<<<< HEAD
            

         [TestMethod()]
        public void LoadCategoriesTest()
        {

            //Arrange
            List<Category> List_Cat = Category.LoadCategories(1); //retrive categroies from market 1


            //Act
            int Size = List_Cat.Count;

            Assert.AreNotEqual(Size, 0);
                           
        }



=======
        [TestMethod()]
        public void LoadCategoriesTest()
        {
            Assert.Fail();
        }
>>>>>>> eef45d079a3e3a62dc3612658845cb2135eccd54
    }
}
