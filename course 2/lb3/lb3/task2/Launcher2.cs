using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task2
{
    internal static class Launcher2
    {
        public static void Run()
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files");
            string textPath = Path.Combine(folder, "text.txt");
            string wordsPath = Path.Combine(folder, "words.txt");

            Censor censor = new Censor();
            censor.Process(textPath, wordsPath);
        }
    }
}
