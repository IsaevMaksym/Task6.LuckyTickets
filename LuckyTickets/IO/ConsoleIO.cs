using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.IO
{
    class ConsoleIO : Iviewer
    {
        private const string PRESS_ANY_KEY = "Press any key...";
        private const string LUCKY_TICKETS = "Here is your lucky tickets: ";

        string Iviewer.GetUserAnswerOnQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        uint Iviewer.GetUserNum(string question)
        {
            uint num = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(question);                
            } while (!uint.TryParse(Console.ReadLine(),out num));

            return num;
        }

        void Iviewer.ShowMessage(string s)
        {
            Console.WriteLine(s);            
        }

        void Iviewer.ShowMessage(IEnumerable<string> enumerator)
        {
            Console.WriteLine(LUCKY_TICKETS);

            foreach (string s in enumerator)
            {
                Console.WriteLine(s.ToString());
            }            
        }

        void Iviewer.MakePause()
        {            
            Console.WriteLine(PRESS_ANY_KEY);
            Console.ReadKey();
        }
    }
}
