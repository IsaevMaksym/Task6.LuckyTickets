using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL
{
   public class MoskowAlgorithm : ILuckyTicketCounterAlgorithm
    {
        private const string AlgorithmName = "Moskow algorithm";

        bool ILuckyTicketCounterAlgorithm.IsTicketLucky(Ticket t)
        {
            int digitsCount = t.DigitLength / 2;
            byte digitsSumBeforeNumHalf=0;
            byte digitsSumAfterNumHalf =0;

            if (t.Number==0)
            {
                return true;
            }

            for (int i = 0; i < t.DigitLength; i++)
            {
                if (i< digitsCount)
                {
                    digitsSumBeforeNumHalf += t[i];
                }
                else
                {
                    digitsSumAfterNumHalf  += t[i];
                }                
            }
            
            return digitsSumBeforeNumHalf == digitsSumAfterNumHalf ;
        }

        public override string ToString()
        {
            return string.Format(AlgorithmName);
        }
    }
}
