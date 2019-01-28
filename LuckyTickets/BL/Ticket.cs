using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL
{
    class Ticket : IDisposable
    {
        private const string TICKET = "Ticket #{0};";
        private byte[] _digits;
        private uint _number;


        public Ticket(uint number, byte[] digits)
        {
            _number = number;

            _digits = digits;
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
