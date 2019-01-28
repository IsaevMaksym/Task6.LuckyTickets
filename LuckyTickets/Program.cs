using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyTickets.Controller;

namespace LuckyTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketController controller = new TicketController();

            controller.Run();
            Console.ReadKey();
        }
    }
}
