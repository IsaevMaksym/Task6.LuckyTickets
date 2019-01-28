﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuckyTickets.BL.Utilities
{
    class PathValidator
    {
        private const string EXTENSION = ".txt";
        private const string INVALID_PATH = "Invalid path {0}";

        private bool _isPathOk;
        
        public bool IsFilePathValid(string userPath)
        {
            _isPathOk = false;

            if ((File.Exists(userPath)) || (Path.GetExtension(userPath) == EXTENSION))
            {
                _isPathOk = true;
            }

            return _isPathOk;
        }

        public string GetFileString(string userPath)
        {
            if (!_isPathOk)
            {
                throw new FileNotFoundException(INVALID_PATH, userPath);
            }

            string FileLine;

            using (StreamReader sr = new StreamReader(userPath))
            {
                FileLine = sr.ReadToEnd();
            }

            return FileLine;
        }

    }
}