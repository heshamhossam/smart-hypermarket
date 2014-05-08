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
    public class CategoryTests
    {
        [Test()]
        public void LoadCategoriesTest()
        {
            //Arrange
            List<Category> List_Cat = Category.LoadCategories(1); //retrive categroies from market 1

            //Act
            int Size = List_Cat.Count;

            Assert.AreNotEqual(Size, 0);
        }
    }
}
