using System;
using System.Collections.Generic;
using Menu_Repository_project;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Menu_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepository _menuRepo;

        private Menu CheeseBurger;
        private List<string> IngListOne;
        //string name, byte number, string description, List< string > listofingredients, decimal price)

        [TestInitialize]

        public void Arrange()
        {
            IngListOne = new List<string> { "cheese", "bun", "beef" };

            CheeseBurger = new Menu("Cheeseburger", 1, "A cheesy burger", IngListOne, 50.0m);
            _menuRepo = new MenuRepository();

            _menuRepo.AddMenuToList(CheeseBurger);
        }
        [TestMethod]
        public void MenuRepositoryAddToList()
        {


            int expected = 1;
            int actual = _menuRepo.GetMenuList().Count;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void MenuRepositoryGetContentByTitle()
        {

            Menu actual = _menuRepo.GetMenuByName("Cheeseburger");

            Assert.AreEqual(CheeseBurger, actual);

        }

        [TestMethod]
        public void MenuRepositoryRemoveFromList()
        {


            bool actual = _menuRepo.RemoveContentFromList(CheeseBurger);

            //int expected = 0;
            //int actual = contentRepo.GetMenuList().Count;

            Assert.IsTrue(actual);


        }




    }
}

