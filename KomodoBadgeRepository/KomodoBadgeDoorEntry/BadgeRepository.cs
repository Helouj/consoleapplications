using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeDoorEntry
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _dictionaryOfBadges = new Dictionary<int, List<string>>();

        

        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _dictionaryOfBadges;

            //repository is a list of badge objects

            //each badge has an ID and list of doors

            //don't bother to save a badge object in the repository, just save the properties as key/value pairs
        }
        public void AddBadge(int id, List<string> door)
        {

            _dictionaryOfBadges.Add(id, door);
            
        }

        

        
    }
}
