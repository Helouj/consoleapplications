using System;
using System.Collections.Generic;
using ClaimsRepo;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTesting
{
    [TestClass]
    public class UnitTest1
    {

        private ClaimRepository _claimRepo;
        //private Queue<ClaimRepository> _claimRepo;
            private Claim TestClaim;

        
        //string name, byte number, string description, List< string > listofingredients, decimal price)

        [TestInitialize]

        public void Arrange()
        {

            TestClaim = new Claim(15310, ClaimType.Home, "someone robbed my house!!!", 50.00m, new DateTime(2019, 7, 21), new DateTime(2019, 8, 30), false);
            _claimRepo = new ClaimRepository();
            _claimRepo.AddClaimToQueue(TestClaim);
           

            
        
        }


        [TestMethod]
        public void ClaimRepositoryAddToList()
        {

           

            
            int expected = 1;

            int actual = _claimRepo.GetClaimCount();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IsWithinThirtyDays()
        {
            DateTime test1 = new DateTime(2019, 7, 1);

            DateTime test2 = new DateTime(2019, 7, 31);

            TimeSpan testDiff = test2 - test1;

            TimeSpan thirtyDays = new TimeSpan(30, 0, 0, 0);

            Assert.AreEqual(thirtyDays.Days, testDiff.Days);

            

        }
        [TestMethod]
        public void TestPeekOfClaimQueue()
        {
            TestClaim = _claimRepo.Peek();

            Assert.IsNotNull(TestClaim);

        }
        [TestMethod]
        public void ClaimRepositoryRemoveFromList()
        {

            int expected = 0;
            _claimRepo.RemoveContentFromQueue();
            int actual = _claimRepo.GetClaimCount();
            //int expected = 0;
            //int actual = contentRepo.GetMenuList().Count;

            Assert.AreEqual(expected, actual);

        }




    }
}



