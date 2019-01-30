using LuckyTickets.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.Test
{
    public class LuckyTIcketAlgorithmsArrComparer : IComparer
    {
      
        public int Compare(object x, object y)
        {
            ILuckyTicketCounterAlgorithm algorithm1 = x as ILuckyTicketCounterAlgorithm;
            ILuckyTicketCounterAlgorithm algorithm2 = y as ILuckyTicketCounterAlgorithm;
            if (algorithm1 == null || algorithm2 == null)
            {
                throw new ArgumentException();
            }

            if (algorithm1.GetType() == algorithm2.GetType())
            {
                return 0;
            }
            else
            {
                return -1;
            }

        }
    }
}
