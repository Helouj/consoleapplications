using KomodoBadgeDoorEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadgeConsole
{
    public class Program
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();

        public static void Main(string[] args)
        {
            ProgramUI program = new ProgramUI();

            program.Run();
        }
    }
}

       