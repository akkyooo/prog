using System;
using System.Collections.Generic;
using System.Text;

namespace lb1.task3.items
{
    internal class PrintJob
    {
        public string User { get; set; }
        public string Document { get; set; }
        public int Priority { get; set; }

        public PrintJob(string user, string document, int priority)
        {
            User = user;
            Document = document;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"Користувач: {User}, документ: {Document}, пріоритет: {Priority}";
        }
    }
}

