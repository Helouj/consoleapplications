using System;
using System.Collections.Generic;
using KomodoBadgeDoorEntry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgeTestRepository
{


    [TestClass]
    public class UnitTest1
    {
        Dictionary<int, List<string>> TestRepo;
        Badge TestBadge;
        [TestInitialize]
        public void Arrange()
        {

            TestRepo = new Dictionary<int, List<string>>();
            TestBadge = new Badge();
            TestBadge.BadgeID = 5;
            TestBadge.ListOfAccessToDoors = new List<string> { "3A", "5B", "Backdoor5"};
            TestRepo.Add(TestBadge.BadgeID, TestBadge.ListOfAccessToDoors);

        }

        [TestMethod]
        public void TestGetBadge()
        {

            Assert.IsNotNull(TestRepo.Keys);
            Assert.IsNotNull(TestRepo.Values);
        }

        [TestMethod]
        public void AddBadge()
        {

            Badge TestBadge1 = new Badge(10, new List<string> { "5A", "3C" });
            int expected = 2;


            TestRepo.Add(TestBadge1.BadgeID, TestBadge1.ListOfAccessToDoors);

            int actual = TestRepo.Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
