using LabApp8.task3.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task3.details
{
    internal class ACipher : ICipher, IComparable<ACipher>
    {
        public string Text {get; set;}
        public ACipher(string text)
        {
            Text = text;
        }
        public string Encode(string text)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                result[i] = char.IsLetter(c) ? c == 'z' ? 'a' : c == 'Z' ? 'A' : (char)(c + 1) : c;
            }
            return new string(result);
        }
        public string Decode(string text)
        {
            char[] result = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                result[i] = char.IsLetter(c) ? c == 'z' ? 'a' : c == 'Z' ? 'A' : (char)(c - 1) : c;
            }
            return new string(result);
        }
        public int CompareTo(ACipher other)
        {
            return Encode(Text).CompareTo(other.Encode(other.Text));
        }
        public override string ToString()
        {
            return Encode(Text);
        }
    }
}
