using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL
{
    class PiterAlgorithm : ILuckyTicketCounterAlgorithm
    {
        private const string AlgorithmName = "Piter algorithm"; 

        bool ILuckyTicketCounterAlgorithm.IsTicketLucky(Ticket t)
        {
            byte oddNumsSum = 0;
            byte evenNumsSum = 0;

            if (t.Number == 0)
            {
                return true;
            }

            for (int i = 0; i < t.DigitLength; i++)
            {
                if ((t[i] % 2) == 0)
                {
                    evenNumsSum += t[i];
                }
                else
                {
                    oddNumsSum += t[i];
                }
            }

            return evenNumsSum == oddNumsSum;            
        }

        public override string ToString()
        {
            return string.Format(AlgorithmName);
        }
    }
}
