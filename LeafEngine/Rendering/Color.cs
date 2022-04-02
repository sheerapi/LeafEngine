using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leaf
{
    /// <summary>
    /// Representation of colors
    /// </summary>
    public class Color
    {
        public int a { get; set; } = 255;
        public int r { get; set; } = 255;
        public int g { get; set; } = 255;
        public int b { get; set; } = 255;

        public Color(int A, int R, int G, int B)
        {
            a = A;
            r = R;
            g = G;
            b = B;
        }

        public static Color Lerp(Color a, Color b, float t)
        {
            return new Color((int)MathL.Lerp(a.a, b.a, t), (int)MathL.Lerp(a.r, b.r, t), (int)MathL.Lerp(a.g, b.g, t), (int)MathL.Lerp(a.b, b.b, t));
        }

        public static Color Black = new Color(255, 0, 0, 0);

        public static Color Red = new Color(255, 255, 0, 0);

        public static Color Green = new Color(255, 0, 255, 0);

        public static Color Blue = new Color(255, 0, 0, 255);

        public static Color Yellow = new Color(255, 255, 255, 0);

    }
}
