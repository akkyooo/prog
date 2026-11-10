using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabApp9.task2.details
{
    internal struct RGBColor
    {
        public int R;
        public int G;
        public int B;
        public void SetColor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }
        public void PrintHEX()
        {
            Console.WriteLine($"HEX: #{R:X2}{G:X2}{B:X2}");
        }
        public void PrintHSL()
        {
            double r = R / 255.0;
            double g = G / 255.0;
            double b = B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            double h = 0;
            double s = 0;
            double l = (max + min) / 2;

            double d = max - min;

            if (d != 0)
            {
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

                if (max == r)
                    h = (g - b) / d;
                else if (max == g)
                    h = (b - r) / d + 2;
                else
                    h = (r - g) / d + 4;

                h *= 60;
                if (h < 0) h += 360;
            }
            Console.WriteLine($"HSL: {h:F1}, {s * 100:F1}%, {l * 100:F1}%");
        }
        public void PrintCMYK()
        {
            double r = R / 255.0;
            double g = G / 255.0;
            double b = B / 255.0;

            double k = 1 - Math.Max(r, Math.Max(g, b));
            double c = 0, m = 0, y = 0;

            if (k != 1)
            {
                c = (1 - r - k) / (1 - k);
                m = (1 - g - k) / (1 - k);
                y = (1 - b - k) / (1 - k);
            }
            Console.WriteLine($"CMYK: {c * 100:F1}%, {m * 100:F1}%, {y * 100:F1}%, {k * 100:F1}%");
        }
    }
}

