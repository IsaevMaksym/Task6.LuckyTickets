using LuckyTickets.BL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL
{
    public class Ticket
    {
        private const string TICKET = "Ticket #{0};";
        private byte[] _digits;
        private uint _number;
        TicketsNumberHelper helper = new TicketsNumberHelper();

        public Ticket(uint number)
        { 
            _number = number;

            _digits = helper.getDigitsOfNum(number);
        }

        public uint Number
        {
            get
            {
                return _number;
            }
        }

        public int DigitLength
        {
            get
            {
                return _digits.Length;
            }
        }

        public byte this[int index]
        {
            get
            {
                return _digits[index];
            }
        }

        public override string ToString()
        {
            return String.Format(TICKET, _number);
        }

    }
}
