using LabApp8.task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task3
{
    internal class BCipher : ICipher, IComparable<BCipher>
    {
        public string Text {get; set;}
        public BCipher(string text)
        {
            Text = text;
        }
        public string Encode(string text)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                result[i] = char.IsLetter(c) ? (char)(char.IsUpper(c) ? 'Z' - (c - 'A') : 'z' - (c - 'a')) : c;
            }
            return new string(result);
        }
        public string Decode(string text)
        {
            return Encode(text);
        }
        public int CompareTo(BCipher other)
        {
            return Encode(Text).CompareTo(other.Encode(other.Text));
        }
    }
}
