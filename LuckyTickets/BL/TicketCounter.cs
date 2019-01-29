using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL
{
    class TicketCounter
    {
       
        private Queue<Ticket> _tickets = new Queue<Ticket>();
        private TicketsNumberHelper _helper = new TicketsNumberHelper();
        private ILuckyTicketCounterAlgorithm _algorithm;

        public TicketCounter()
            : this(new MoskowAlgorithm())
        {
        }

        public TicketCounter(ILuckyTicketCounterAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public void CountTickets(uint ticketsMaxNumber)
        {
            Ticket ticket;

            for (uint i = 0; i <= ticketsMaxNumber; i++)
            {
                ticket = new Ticket(i, _helper.getDigits(i));

                if (_algorithm.IsTicketLucky(ticket))
                {
                    _tickets.Enqueue(ticket);
                }                
            }
        }

        public virtual IEnumerable<string> GetLuckyTicketsList()
        {
            if (_tickets.Count == 0)
            {
                yield return "0";
            }
            foreach (Ticket t in _tickets)
            {
                yield return t.ToString();
            }
        }

        public int LuckyTiketsCount
        {
            get
            {
                return _tickets.Count();
            }
        }

        public string AlgorithmName
        {
            get
            {
                return _algorithm.ToString();
            }
        }
    }
}
