using LabApp11.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp11.models
{
    public class Newspaper : ILibraryItem
    {
        public string Title {get; set;}
        public DateTime Date {get; set;}
        private string[] headlines = new string[0];
        public void AddHeadline(string headline)
        {
            string[] newArr = new string[headlines.Length + 1];
            for (int i = 0; i < headlines.Length; i++)
                newArr[i] = headlines[i];
            newArr[newArr.Length - 1] = headline;
            headlines = newArr;
        }
        public string GetInfo()
        {
            return $"[Newspaper] {Title}, Date: {Date.ToShortDateString()}, Headlines: {headlines.Length}";
        }
    }
}

