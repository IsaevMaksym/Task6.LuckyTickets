using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL
{
    public class TicketsNumberHelper
    {
        public byte[] getDigits(uint number)
        {
            List<byte> digitsArr = new List<byte>();

            while (number != 0)
            {
                digitsArr.Add((byte)(number % 10));
                number /= 10;
            }

            while (digitsArr.Count < 6)
            {
                digitsArr.Add(0);
            }

            if ((digitsArr.Count % 2) == 1)
            {
                digitsArr.Add(0);
            }

            digitsArr.Reverse();
            return digitsArr.ToArray();
        }

    }
}
