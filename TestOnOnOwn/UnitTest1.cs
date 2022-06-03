using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnOnOwn;
using System.Collections.Generic;

namespace TestOnOnOwn
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddMenu()
        {
            DataAccess.AddMenu("Dish", 100, "Nice Dish", 2, 1, false, false);
            
        }
        [TestMethod]
        public void TestAddOrderMenu()
        {
            DataAccess.AddOrderMenu(1,100,5,false);
        }
        [TestMethod]
        public void TestDeleteDish(menu menu)
        {
            DataAccess.DeleteDish(menu);
        }
        [TestMethod]
        public void GetAllMenu()
        {
            DataAccess.RemoveDish(1);
        }

    }
}
