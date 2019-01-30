using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyTickets.Resourses;
using System.Text.RegularExpressions;

namespace LuckyTickets.BL.Utilities
{
    public class AlgorythmTypeValidator
    {
        private Regex regex;
        private MatchCollection match;
        private const string PITER_ALGORITHM = "piter";
        private const string MOSKOW_ALGORITHM = "moskow";

        public ILuckyTicketCounterAlgorithm[] GetAlgorythmType(string FileLine)
        {
            return GetTicketCounters(GetMatches(FileLine));
        }

        private string[] GetMatches(string currentLine)
        {
            Queue<string> arr = new Queue<string>();

            for (int i = 0; i < AlgorythmName.algorythmSearchPattern.Count; i++)
            {
                string pattern = AlgorythmName.algorythmSearchPattern[i];
                regex = new Regex(pattern);

                match = regex.Matches(currentLine);

                if (match.Count != 0)
                {
                    arr.Enqueue(match[0].Value.Trim());
                }
            }

            return arr.ToArray<string>();
        }

        private ILuckyTicketCounterAlgorithm[] GetTicketCounters(string[] args)
        {
            if (args == null)
            {
                return null;
            }

            Queue<ILuckyTicketCounterAlgorithm> counters = new Queue<ILuckyTicketCounterAlgorithm>();            

            for (int i = 0; i < args.Length; i++)
            {
                ILuckyTicketCounterAlgorithm algorithm = null;
                if (args[i]== PITER_ALGORITHM)
                {
                    algorithm = new PiterAlgorithm();
                }
                if (args[i] == MOSKOW_ALGORITHM)
                {
                    algorithm = new MoskowAlgorithm();
                }
                if (algorithm != null)
                {
                    counters.Enqueue(algorithm);
                }
                
            }
           
            return counters.ToArray<ILuckyTicketCounterAlgorithm>();
        }
                
    }
}
