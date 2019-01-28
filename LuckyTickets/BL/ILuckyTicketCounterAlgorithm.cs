using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.BL
{
    interface ILuckyTicketCounterAlgorithm
    {
        bool IsTicketLucky(Ticket t);
               
    }
}
