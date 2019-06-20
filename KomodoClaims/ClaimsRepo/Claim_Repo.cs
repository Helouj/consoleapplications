using System;
using System.Collections.Generic;

namespace ClaimsRepo
{
    public class ClaimRepository
    {


        private Queue<Claim> _queueOfClaimItems = new Queue<Claim>();

        public void AddClaimToQueue(Claim claim)
        {

            _queueOfClaimItems.Enqueue(claim);

        }

        public Queue<Claim> GetClaimQueue()
        {
            return _queueOfClaimItems;

        }
        public int GetClaimCount()
        {
            return _queueOfClaimItems.Count;
        }
        
        public void RemoveContentFromQueue()
        {
            _queueOfClaimItems.Dequeue();

        }

        public void DetermineIsValid(Claim claim)
        {
            if (claim.DateOfClaim < claim.DateOfIncident)
                claim.DateOfClaim = claim.DateOfIncident;


            TimeSpan diff = claim.DateOfClaim - claim.DateOfIncident;

            if (diff.Days <= 30)
            {
                claim.IsValid = true;
            }
            else
                claim.IsValid = false;

        }

        public Claim Peek()
        {
            return _queueOfClaimItems.Peek();

        }



    }

}



