
using Menu_Repository_project;
using System;
using System.Collections.Generic;

namespace Menu_main
{
    public class ProgramUI
    {

        private MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            // Console.Beep();
            SeedmenuList();
            RunMenu();

        }

        private void RunMenu()
        {

            bool continueToRunMenu = true;


            while (continueToRunMenu)
            {
                //Console.Beep();
                //System.Media.SystemSounds.Beep.Play();
                Console.Clear();
                Console.WriteLine("What would you like to do?  Enter a number, yeah?\n" +
                    "1. Show all menu\n" +
                    //"2. Find streaming menu by name\n" +
                    "2. Add new menu\n" +
                    "3. Remove menu\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {

                    case "1"://show all
                        ShowAllmenu();
                        break;
                    //case "2"://find by name
                    //    ShowmenuByname();
                    //    break;
                    case "2":// add new
                        AddNewmenu(0);
                        break;
                    case "3"://remove
                             //Menu menu = ShowmenuByname();
                        RemoveMenuByName();
                        break;
                    //case "5"://update menu by name
                    //    UpdatemenuByname();


                    //    break;

                    case "4"://exit the program
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

            }



        }

        private void RemoveMenuByName()
        {
            List<Menu> listOfMenuItems = _menuRepo.GetMenuList();

            Console.WriteLine("Enter the name you'd like to remove: ");
            string name = Console.ReadLine();

            Menu menu = ShowMenuItemByName(name);

            listOfMenuItems.Remove(menu);

            Console.WriteLine("menu removed.  Press a key to continue...");
            Console.ReadKey();

        }

        private void AddNewmenu(int index)
        {

            bool enteringIngredients = true;
            Menu menu = new Menu();
            Console.Write("Enter name: ");

            menu.Name = Console.ReadLine();
            List<string> TempIngList = new List<string>();



            //string futureenum = Console.ReadLine();
            //GenreType genre = (GenreType)Enum.Parse(typeof(GenreType), futureenum);
            // menu.TypeOfGenre = genre;

            Console.Write("Enter Menu Number: ");
            //Cheeseburger", 1, "A cheesy burger", IngListOne, 50.0m
            menu.Number = Convert.ToByte(Console.ReadLine());
            Console.Write("Enter Description: ");
            menu.Description = Console.ReadLine();



            while (enteringIngredients)
            {

                Console.WriteLine("Enter ingredients and press enter after each.  When done, type in 'done' followed by the enter key");

                string temp = Console.ReadLine();

                if (temp == "done" && TempIngList.Count > 0)
                {

                    enteringIngredients = false;
                }
                else
                {
                    TempIngList.Add(temp);
                }


            }
            menu.ListOfIngredients = TempIngList;
            Console.WriteLine("Enter a price: ");
            menu.Price = Convert.ToDecimal(Console.ReadLine());



            _menuRepo.AddMenuToList(menu);

            Console.WriteLine("Successfully added.  list is as follows:\n");

            ShowAllmenu();
            Console.ReadKey();
            // Menu rubber = new Menu("Rubber", GenreType.Horror, "A bad movie", 120d, 5.8d, "R", false);

        }
        private Menu ShowMenuItemByName(string name)
        {

            //List<Menu> listOfMenuItems = _menuRepo.GetMenuList();
            //Console.WriteLine("enter name: ");
            //string input = Console.ReadLine();

            Menu menu = _menuRepo.GetMenuByName(name);

            if (menu == null)
            {
                Console.WriteLine("Didn't find what you were looking for.  Apologies sir/madam~");
                return null;
            }
            else
            {
                //Cheeseburger", 1, "A cheesy burger", IngListOne, 50.0m
                Console.WriteLine($"\nname: {menu.Name} \n" + $"Menu number: {menu.Number}\n " + $"Description: {menu.Description} \n" + $"Price: {menu.Price}");
                Console.Write("Ingredients list is: ");
                foreach (string item in menu.ListOfIngredients)
                {
                    Console.WriteLine($"{item}, ");
                }

                Console.WriteLine("press a key to continue");
                Console.ReadKey();
                return menu;
            }




        }
        private void ShowAllmenu()
        {
            List<Menu> listOfMenuItems = _menuRepo.GetMenuList();
            foreach (Menu menu in listOfMenuItems)
            {
                Console.WriteLine($"{menu.Name} {menu.Description}");

            }
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();

            //throw new NotImplementedException();
        }

        private void SeedmenuList()
        {

            List<string> IngListOne = new List<string> { "cheese", "bun", "beef" };
            List<string> IngListTwo = new List<string> { "potatoes", "salt", "oil" };
            List<string> IngListThree = new List<string> { "chicken", "seasoning", "breading" };
            //string name, byte number, string description, List< string > listofingredients, decimal price)
            Menu CheeseBurger = new Menu("Cheeseburger", 1, "A cheesy burger", IngListOne, 50.0m);

            Menu Fries = new Menu("Fries", 2, "Some salty fries", IngListTwo, 33.0m);

            Menu Chicken = new Menu("Chicken", 3, "Some chicken tenders", IngListThree, 25.0m);


            _menuRepo.AddMenuToList(CheeseBurger);
            _menuRepo.AddMenuToList(Fries);
            _menuRepo.AddMenuToList(Chicken);





        }
    }
}


