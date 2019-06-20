using KomodoBadgeDoorEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeConsole
{
    public class ProgramUI
    {
        private BadgeRepository _badgeRepo;


        public void Run()
        {

            SeedBadgeDictionary();
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
                _badgeRepo.GetBadgeList();
                Console.Clear();
                Console.WriteLine("What would you like to do?  Enter a number, yeah?\n" +
                    "1. Add a new badge\n" +

                    "2. edit a badge\n" +
                    "3. list all badges\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "1"://add a badge
                        AddNewBadge();
                        //();

                        break;


                    case "2"://edit/update a badge
                        
                        RemoveAddDoors();
                        
                        break;
                    case "3"://list all badges
                        //AddNewclaim(0);
                        ShowAllBadges();

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
        public void SeedBadgeDictionary()
        {

            //Badge Accident3 = new Badge(1539, ClaimType.Car, "Twitch was here!", 50.00m, new DateTime(2018, 2, 15), new DateTime(2019, 6, 30), false);
            //_badgeRepo.DetermineIsValid(Accident1);
            // List<string> temp = new List<string> { "A56", "B32" };
            _badgeRepo = new BadgeRepository();
            Badge badge1 = new Badge(3, new List<string> { "A56", "B32" });
            _badgeRepo.AddBadge(badge1.BadgeID, badge1.ListOfAccessToDoors);

        }


        private void RemoveAddDoors()
        {
            Dictionary<int, List<string>> dictionaryOfBadges = _badgeRepo.GetBadgeList();
            List<string> templist;
            
            Console.WriteLine("enter ID of a badge you'd like to change:");
            int badgeid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add or Remove?:");
            string temp1 = Console.ReadLine();            

            if(temp1 == "Add")
            {

                Console.WriteLine("Enter a door to add: ");
                string temp = Console.ReadLine();
                dictionaryOfBadges.TryGetValue(badgeid, out templist);
                templist.Add(temp);
                dictionaryOfBadges.Remove(badgeid);
                dictionaryOfBadges.Add(badgeid, templist);

                
            }else if(temp1 == "Remove")
            {
                Console.WriteLine("Enter a door to remove: ");
                string temp = Console.ReadLine();
                dictionaryOfBadges.TryGetValue(badgeid, out templist);
                templist.Remove(temp);
                dictionaryOfBadges.Remove(badgeid);
                dictionaryOfBadges.Add(badgeid, templist);
            }
            else { Console.WriteLine("you derped on the input there.  returning to main menu, try again!");
            }
            

        }
        


        private void AddNewBadge()
        {


            Badge badge = new Badge();
            badge.ListOfAccessToDoors = new List<string>();
            Console.Write("Enter BadgeID(no letters): ");

            //Int32.TryParse(Console.ReadLine(), out int input);

            badge.BadgeID = Convert.ToInt32(Console.ReadLine());

            //badge.ClaimID = Try.Parse(Console.ReadLine());

            bool stillEntering = true;
            Console.Write("Enter a list of doors to give the badgeholder access to, type  Done when finished");
            while (stillEntering)
            {


                

                string input = Console.ReadLine();

                if (input == "Done" || input == "done")
                {
                    stillEntering = false;
                }
                else
                {

                    badge.ListOfAccessToDoors.Add(input);
                }
            }


            _badgeRepo.AddBadge(badge.BadgeID, badge.ListOfAccessToDoors);

            Console.WriteLine("Successfully added. Dictionary is as follows:\n");

        }

        private void ShowAllBadges()
        {
            Dictionary<int, List<string>> dictionaryOfBadges = _badgeRepo.GetBadgeList();
            List<string> templist;
            Console.WriteLine("Badge #    has access to doors:");
            foreach(KeyValuePair<int, List<string>> item in dictionaryOfBadges)
            {
                Console.WriteLine();
                Console.Write(item.Key);
                dictionaryOfBadges.TryGetValue(item.Key,out templist);
                Console.Write("             ");
                foreach(string door in templist)
                {
                    Console.Write(door + ", ");

                }
            }

            

            
            Console.WriteLine("\nPress any key to continue...");

            Console.ReadKey();

            //throw new NotImplementedException();
        }
    }
}

   