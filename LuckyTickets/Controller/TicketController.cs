using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LuckyTickets.BL;
using LuckyTickets.IO;
using LuckyTickets.BL.Utilities;

namespace LuckyTickets.Controller
{
    class TicketController
    {
        private const string RULES = "Enter file path, witch should contain lucky tickets search algorithm name (Moskow or Piter)";
        private const string GET_FILE_PATH = @"Enter file path(e.g. <disk_name>:\<folder_name>\<file_name>.txt).";
        private const string GET_FILE_PATH_PART_TWO = "\nOtherwise click 'Enter' to close the program ";
        private const string TICKETS_MAX_LIMIT = " max limit of tikets, or enter 0, if you want to use defaul limit(999999).";
        private const string TICKETS = " lucky tikets";
        private const uint DEFAULT_LIMIT = 999999;

        #region Private variables

        private Iviewer _viewer;

        List<TicketCounter> _counters = new List<TicketCounter>();

        #endregion

        public TicketController()
            : this(new ConsoleIO())
        {
        }

        public TicketController(Iviewer viewer)
        {
            _viewer = viewer;
        }

        public void Run()
        {
            _viewer.ShowMessage(RULES);
            _viewer.MakePause();

            ILuckyTicketCounterAlgorithm[] _algorithmsArr;

            try
            {
                _algorithmsArr = GetAlgorithmsArr();
            }
            catch (ArgumentNullException a)
            {
                _viewer.ShowMessage(a.Message);
                _viewer.ShowClosingMessage();
                return;
            }
            catch (Exception)
            {
                return;
            }            

            AddAlgorithmCountersToList(_algorithmsArr);

            foreach (TicketCounter counter in _counters)
            {
                _viewer.ShowMessage(counter.AlgorithmName);
                _viewer.ShowMessage(counter.LuckyTiketsCount.ToString() + TICKETS);
                
            }

            _viewer.MakePause();
            _viewer.ShowClosingMessage();
        }

        private void AddAlgorithmCountersToList(ILuckyTicketCounterAlgorithm[] _algorithmsArr)
        {
            uint limit = 0;
            TicketCounter _ticketCounter = null;

            foreach (ILuckyTicketCounterAlgorithm algorithm in _algorithmsArr)
            {
                _viewer.ShowMessage(algorithm.ToString());

                _ticketCounter = new TicketCounter(algorithm);

                limit = GetAlgorithmTicketMaxLimit(algorithm.ToString());

                if (limit == 0)
                {
                    limit = DEFAULT_LIMIT;
                }

                _ticketCounter.CountTickets(limit);

                _counters.Add(_ticketCounter);

            }
        }

        private ILuckyTicketCounterAlgorithm[] GetAlgorithmsArr()
        {
            ILuckyTicketCounterAlgorithm[] algorythmsArr = null;

            do
            {
                algorythmsArr = GetAlgorithmsFromFile();

            } while (algorythmsArr == null);

            return algorythmsArr;
        }

        private ILuckyTicketCounterAlgorithm[] GetAlgorithmsFromFile()
        {
            string path;
            PathValidator _pathValidator = new PathValidator();
            AlgorythmTypeValidator _typeValidator = new AlgorythmTypeValidator();

            do
            {
                path = _viewer.GetUserAnswerOnQuestion(GET_FILE_PATH+ GET_FILE_PATH_PART_TWO);

                if (string.IsNullOrWhiteSpace(path))
                {
                    throw new ArgumentNullException();
                }

            } while (!_pathValidator.IsFilePathValid(path));

            return _typeValidator.GetAlgorythmType(_pathValidator.GetFileString(path));
        }

        private uint GetAlgorithmTicketMaxLimit(string algorithmName)
        {
            return _viewer.GetUserNum(algorithmName + TICKETS_MAX_LIMIT);
        }
    }
}
