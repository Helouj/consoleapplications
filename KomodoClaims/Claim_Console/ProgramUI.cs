using ClaimsRepo;
using System;
using System.Collections.Generic;

namespace Claim_Repo
{

    public class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
           
            SeedClaimQueue();
            RunMenu();

        }

        private void RunMenu()
        {
            //Console.SetWindowSize(50, 52);
            //Console.WindowHeight = 700;
            //Console.WindowWidth = 500;
            bool continueToRunMenu = true;


            while (continueToRunMenu)
            {
                
                Console.Clear();
                Console.WriteLine("What would you like to do?  Enter a number, yeah?\n" +
                    "1. Show all claim\n" +
                   
                    "2. Remove claim\n" +
                    "3. Add new claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "1"://see all claims
                        ShowAllclaim();
                        break;
                   

                    case "2":// take care of next claim/remove
                        RemoveClaim();
                        break;
                    case "3"://add new claim
                        AddNewclaim(0);
                             
                        break;
                   

                    case "4"://exit the program
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }



        }

        private void RemoveClaim()
        {
            _claimRepo.GetClaimQueue();

            Claim TopClaim = _claimRepo.Peek();

            Console.WriteLine("Here are the details for the next claim to be handled: ");

            Console.WriteLine($"ClaimID: {TopClaim.ClaimID} \n Type: {TopClaim.TypeOfClaim} \n Description: {TopClaim.Description} \n                           Amount: {TopClaim.ClaimAmount} \n DateOfIncident: {TopClaim.DateOfIncident.ToString()} \n DateOfClaim:  {TopClaim.DateOfClaim.ToString()} \n  IsValid: {TopClaim.IsValid} \n\n  Do you want to deal with this claim now(y/n)? ");

            string input = Console.ReadLine();

            //Claim claim = ShowMenuItemByName(name);
            if (input == "y")
            {
                _claimRepo.RemoveContentFromQueue();
                Console.WriteLine("claim removed.  Press a key to continue...");
                Console.ReadKey();
            }


        }

        

        private void AddNewclaim(int index)
        {

            
            Claim claim = new Claim();
            Console.Write("Enter ClaimID: ");

            Int32.TryParse(Console.ReadLine(), out int input );

            claim.ClaimID = input;

            //claim.ClaimID = Try.Parse(Console.ReadLine());

            Console.Write("Enter number to select type of claim(house = 1, theft = 2, car = 3): ");

            claim.TypeOfClaim = (ClaimType)Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Description: ");
            claim.Description = Console.ReadLine();

            Console.Write("Enter $amount of claim: ");
            Decimal.TryParse(Console.ReadLine(), out Decimal inputD);
            claim.ClaimAmount = inputD;

            //claim.ClaimAmount = Console.ReadLine();
            
            Console.Write("Enter Date Of Accident Year, Month, Day: ");


            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Date Of Claim Year, Month, Day: ");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            //int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid


            _claimRepo.DetermineIsValid(claim);

            _claimRepo.AddClaimToQueue(claim);

            Console.WriteLine("Successfully added.  queue is as follows:\n");

            ShowAllclaim();
            
           

        }
        
        private void ShowAllclaim()
        {
            Queue<Claim> queueOfClaims = _claimRepo.GetClaimQueue();

            Console.WriteLine("ClaimID     Type     Amount     DateOfAccident     DateOfClaim     IsValid");

            foreach (Claim claim in queueOfClaims)
            {
                //int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid
                
                Console.WriteLine($" {claim.ClaimID}     {claim.TypeOfClaim}     {claim.Description}     {claim.ClaimAmount}     {claim.DateOfIncident}     {claim.DateOfClaim}     {claim.IsValid}");

            }
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

            //throw new NotImplementedException();
        }

        private void SeedClaimQueue()
        {

            //new DateTime()



            

            
            //int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid
            Claim Accident1 = new Claim(1538, ClaimType.Theft, "Kevin Mcallister was unsucessful", 50.00m, new DateTime(2019, 6, 1),  new DateTime(2019, 6, 15), false);
            
           
            Claim Accident2 = new Claim(15310, ClaimType.Home, "someone robbed my house!!!", 50.00m, new DateTime(2019, 7, 21), new DateTime(2019, 8, 30), false);

            Claim Accident3 = new Claim(1539, ClaimType.Car, "Twitch was here!", 50.00m, new DateTime(2018, 2, 15), new DateTime(2019, 6, 30), false);
            _claimRepo.DetermineIsValid(Accident1);
            _claimRepo.DetermineIsValid(Accident2);
            _claimRepo.DetermineIsValid(Accident3);


            _claimRepo.AddClaimToQueue(Accident1);
            _claimRepo.AddClaimToQueue(Accident2);
            _claimRepo.AddClaimToQueue(Accident3);
            

           





        }
    }
}



