using System;
using System.Collections.Generic;
using System.Text;

namespace lb1.task3.items
{
    internal class PrintStatistics
    {
        public string User { get; set; }
        public string Document { get; set; }
        public DateTime PrintTime { get; set; }

        public PrintStatistics(string user, string document)
        {
            User = user;
            Document = document;
            PrintTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{User} | {Document} | {PrintTime:dd.MM.yyyy HH:mm:ss}";
        }
    }
}
