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
        public static Dictionary<string, ILuckyTicketCounterAlgorithm> algorythmRef = new Dictionary<string, ILuckyTicketCounterAlgorithm>()
        {
            {"moskow", new MoskowAlgorithm()},
            {"piter", new PiterAlgorithm()}
        };

        public static Dictionary<int, string> algorythmSearchPattern = new Dictionary<int, string>()
        {
            {0 , @"(\w*|\s*)moskow(\w*|\s*)"},
            {1 , @"(\w*|\s*)piter(\w*|\s*)"}
        };
    }
}
