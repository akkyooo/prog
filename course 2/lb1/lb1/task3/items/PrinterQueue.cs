using System;
using System.Collections.Generic;
using System.Text;

namespace lb1.task3.items
{
    internal class PrinterQueue
    {
        private Queue<PrintJob> queue = new Queue<PrintJob>();
        private List<PrintStatistics> statistics = new List<PrintStatistics>();

        public void AddJob(PrintJob job)
        {
            queue.Enqueue(job);
            Console.WriteLine("Запит додано до черги.");
        }

        public void DisplayQueue()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Черга друку порожня.");
                return;
            }

            List<PrintJob> jobs = new List<PrintJob>(queue);

            for (int i = 0; i < jobs.Count - 1; i++)
            {
                for (int j = 0; j < jobs.Count - i - 1; j++)
                {
                    if (jobs[j].Priority < jobs[j + 1].Priority)
                    {
                        PrintJob temp = jobs[j];
                        jobs[j] = jobs[j + 1];
                        jobs[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nЧерга друку:");

            foreach (PrintJob job in jobs)
            {
                Console.WriteLine(job);
            }
        }

        public void PrintNext()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Черга друку порожня.");
                return;
            }

            Queue<PrintJob> tempQueue = new Queue<PrintJob>();
            PrintJob selectedJob = null;

            foreach (PrintJob job in queue)
            {
                if (selectedJob == null || job.Priority > selectedJob.Priority)
                {
                    selectedJob = job;
                }
            }

            bool removed = false;

            foreach (PrintJob job in queue)
            {
                if (!removed && job == selectedJob)
                {
                    removed = true;
                    continue;
                }

                tempQueue.Enqueue(job);
            }

            queue = tempQueue;

            Console.WriteLine("\nДрукується документ: " + selectedJob.Document);
            Console.WriteLine("Користувач: " + selectedJob.User);

            statistics.Add(
                new PrintStatistics(selectedJob.User, selectedJob.Document));

            Console.WriteLine("Друк завершено.");
        }

        public void DisplayStatistics()
        {
            if (statistics.Count == 0)
            {
                Console.WriteLine("Статистика друку відсутня.");
                return;
            }

            Console.WriteLine("\nСтатистика друку:");

            foreach (PrintStatistics item in statistics)
            {
                Console.WriteLine(item);
            }
        }

        public void SaveStatistics(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (PrintStatistics item in statistics)
                {
                    writer.WriteLine(item);
                }
            }

            Console.WriteLine("Статистику збережено у файл.");
        }
    }
}
