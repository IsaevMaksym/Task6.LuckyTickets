using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL
{
    public class TicketCounter
    {       
        private Queue<Ticket> _tickets = new Queue<Ticket>();        
        private ILuckyTicketCounterAlgorithm _algorithm;

        public TicketCounter()
            : this(new MoskowAlgorithm())
        {
        }

        public TicketCounter(ILuckyTicketCounterAlgorithm algorithm)
        {
            _algorithm = algorithm;
        }

        public int CountTickets(uint ticketsMaxNumber)
        {            
            for (uint i = 0; i <= ticketsMaxNumber; i++)
            {
                Ticket ticket = new Ticket(i);

                if (_algorithm.IsTicketLucky(ticket))
                {
                    _tickets.Enqueue(ticket);
                }                
            }

            return LuckyTiketsCount;
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
