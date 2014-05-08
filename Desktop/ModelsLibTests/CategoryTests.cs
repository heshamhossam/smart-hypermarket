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
            List<Category> ret = Category.LoadCategories(1, "http://zonlinegamescom.ipage.com/smarthypermarket/public/mocks/categories/retrieve‎‎"); //retrive categroies from market 1
            //Assert
            Assert.AreEqual("Test", ret[0].Name);
        }
    }
}
