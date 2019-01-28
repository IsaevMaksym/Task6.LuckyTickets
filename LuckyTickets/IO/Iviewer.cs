using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyTickets.IO
{
    interface Iviewer
    {
        void ShowMessage(string s);

        void ShowMessage(IEnumerable<string> enumerator);

        void MakePause();

        string GetUserAnswerOnQuestion(string question);

        uint GetUserNum(string question);
    }
}
