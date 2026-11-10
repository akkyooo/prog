using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp10.task3.details
{
    internal static class TextUtils
    {
        public delegate bool TextCheck(string text, string[] words);
        public static TextCheck ContainsWords = (text, words) => words.Any(w => text.Contains(w));
    }
}
