using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyTickets.BL;

namespace LuckyTickets.Resourses
{
    class AlgorythmName
    {

        public static Dictionary<int, string> algorythmSearchPattern = new Dictionary<int, string>()
        {
            {0 , @"(\W*|\s*)moskow(\W*|\s*)"},
            {1 , @"(\W*|\s*)piter(\W*|\s*)"}
        };
                
    }
}
