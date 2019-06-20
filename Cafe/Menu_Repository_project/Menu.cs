using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Repository_project
{
    public class Menu
    {




        public Menu()
        {


        }
        public Menu(string name, byte number, string description, List<string> listofingredients, decimal price)
        {
            Name = name;
            Number = number;
            Description = description;
            ListOfIngredients = listofingredients;
            Price = price;
        }




        public string Name { get; set; }
        public byte Number { get; set; }
        public string Description { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public decimal Price { get; set; }





    }


}


