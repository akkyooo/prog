using System;
using System.Collections.Generic;
using System.Text;

namespace lb3.task1
{
    internal static class Launcher1
    {
        public static void Run()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "text.txt");
            FileAnalyzer analyzer = new FileAnalyzer();
            analyzer.Analyze(path);
        }
    }
}