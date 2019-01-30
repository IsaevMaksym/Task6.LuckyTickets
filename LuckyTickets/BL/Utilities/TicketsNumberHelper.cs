using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL.Utilities
{
    public class TicketsNumberHelper
    {
        #region Constants
       
        private const int TICKETS_MIN_DIGITS_COUNT = 6;
        private const int NUM_TWO = 2;
        private const int NUM_TEN = 10;

        #endregion

        public byte[] getDigitsOfNum(uint number)
        {
            List<byte> digitsArr = new List<byte>();

            while (number != 0)
            {
                digitsArr.Add((byte)(number % NUM_TEN));
                number /= NUM_TEN;
            }

            while (digitsArr.Count < TICKETS_MIN_DIGITS_COUNT)
            {
                digitsArr.Add(0);
            }

            if ((digitsArr.Count % NUM_TWO) == 1)
            {
                digitsArr.Add(0);
            }

            digitsArr.Reverse();

            return digitsArr.ToArray();
        }

    }
}
