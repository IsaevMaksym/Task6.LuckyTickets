using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyTickets.Resourses;
using System.Text.RegularExpressions;

namespace LuckyTickets.BL.Utilities
{
    class AlgorythmTypeValidator
    {
        private Regex regex;
        private MatchCollection match;

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
                    arr.Enqueue(match[0].Value);
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
            
            foreach (string s in args)
            {
                counters.Enqueue(AlgorythmName.algorythmRef[s.Trim()]);
            }

            return counters.ToArray<ILuckyTicketCounterAlgorithm>();
        }

    }
}
