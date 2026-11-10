using LabApp8.task3.details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp8.task3
{
    public static class Task3Launcher
    {
        public static void Run()
        {
            {
                string[] text = { "Hello", "World", "Test" };

                ACipher aCipher = new ACipher("");
                BCipher bCipher = new BCipher("");

                for (int i = 0; i < text.Length; i++)
                {
                    aCipher.Text = text[i];
                    bCipher.Text = text[i];
                    Console.WriteLine($"Original Text: {text[i]}");

                    string aEnc = aCipher.Encode(text[i]);
                    string bEnc = bCipher.Encode(text[i]);

                    Console.WriteLine($"ACipher Encoded: {aEnc}");
                    Console.WriteLine($"ACipher Decoded: {aCipher.Decode(aEnc)}");

                    Console.WriteLine($"BCipher Encoded: {bEnc}");
                    Console.WriteLine($"BCipher Decoded: {bCipher.Decode(bEnc)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
    
