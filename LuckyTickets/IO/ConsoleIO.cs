using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.IO
{
    class ConsoleIO : Iviewer
    {
        private const int CLOSING_ITERATION_TIME = 800;
        private const int CLOSING_ITERATIONS_COUNT = 3;
        private const string CLOSE_MSG = "Application has ended.";
        private const string CLOSING_MESSAGE = "Closing app";
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

        void Iviewer.ShowClosingMessage()
        {
            Console.WriteLine(CLOSE_MSG);
            Console.Write(CLOSING_MESSAGE);
            
            for (int i = 0; i < CLOSING_ITERATIONS_COUNT; i++)
            {
                System.Threading.Thread.Sleep(CLOSING_ITERATION_TIME);
                Console.Write(".");
            }
        }
    }
}
