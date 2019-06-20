using System;
using System.Collections.Generic;
using System.Text;

namespace Menu_Repository_project
{
    public class MenuRepository
    {

        private List<Menu> _listOfMenuItems = new List<Menu>();

        public void AddMenuToList(Menu menu)
        {

            _listOfMenuItems.Add(menu);

        }

        public List<Menu> GetMenuList()
        {
            return _listOfMenuItems;

        }
        public Menu GetMenuByName(string name)
        {
            foreach (Menu menu in _listOfMenuItems)
            {

                if (menu.Name.ToLower() == name.ToLower())
                {
                    return menu;
                }


            }
            return null;
        }
        public bool RemoveContentFromList(Menu menu)
        {
            int initialCount = _listOfMenuItems.Count;

            _listOfMenuItems.Remove(menu);

            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            return false;

        }




    }

}

