using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeDoorEntry
{
    public class Badge
    {

        public Badge()
        { }

        public Badge(int badgeID, List<string> listOfAccessToDoors)
        {
            BadgeID = badgeID;

            ListOfAccessToDoors = listOfAccessToDoors;
        }

        public int BadgeID { get; set; }
        public List<string> ListOfAccessToDoors { get; set; }

        
        


    }


}

